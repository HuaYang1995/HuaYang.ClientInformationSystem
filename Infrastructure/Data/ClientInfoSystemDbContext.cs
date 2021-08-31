using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Infrastructure.Data
{
    public class ClientInfoSystemDbContext: DbContext
    {
        public ClientInfoSystemDbContext(DbContextOptions<ClientInfoSystemDbContext> options) : base(options) { 
        
        }
        public DbSet<Employees> Employee { get; set; }

        public DbSet<Clients> Client { get; set; }

        public DbSet<Interactions> Interaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(ConfigureEmployee);
            modelBuilder.Entity<Clients>(ConfigureClient);
            modelBuilder.Entity<Interactions>(ConfigureInteraction);
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employees> builder) {
            builder.ToTable("Employees");
            builder.HasKey(e=> e.Id);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Password).HasMaxLength(10);
            builder.Property(e => e.Designation).HasMaxLength(50);
        }

        private void ConfigureClient(EntityTypeBuilder<Clients> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Email).HasMaxLength(50);
            builder.Property(c => c.Phones).HasMaxLength(30);
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.AddedOn).HasDefaultValueSql("getdate()");
        }

        private void ConfigureInteraction(EntityTypeBuilder<Interactions> builder)
        {
            builder.ToTable("Interactions");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.ClientId);
            builder.Property(i => i.EmpId);
            builder.Property(i => i.IntType).HasMaxLength(1);
            builder.Property(i => i.IntDate).HasDefaultValueSql("getdate()");
            builder.Property(i => i.Remarks).HasMaxLength(500);
            builder.HasOne(i => i.Clients).WithMany(i => i.Interaction).HasForeignKey(i => i.ClientId);
            builder.HasOne(i => i.Employees).WithMany(i => i.Interaction).HasForeignKey(i => i.EmpId);

        }

    }
}
