using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InteractionsRepository : EfRepository<Interactions>,IInteractionRepository
    {
        public InteractionsRepository(ClientInfoSystemDbContext dbContext) : base (dbContext)
        {

        }


        public async Task<IEnumerable<Interactions>> GetInterationsByClientId(int clientid)
        {
            var interactionClient = await _dbContext.Interaction.Include(e =>e.Employees).Where(i => i.ClientId == clientid).ToListAsync();
            return interactionClient;
        }

        public async Task<IEnumerable<Interactions>> GetInterationsByEmployeeId(int employeeid)
        {
            var interactionEmployee = await _dbContext.Interaction.Include(c =>c.Clients).Where(i => i.EmpId == employeeid).ToListAsync();
            return interactionEmployee;
        }

        public async Task<IEnumerable<Interactions>> GetAllInteractions()
        {
            var getInteractions = await _dbContext.Interaction.ToListAsync();

            return getInteractions;
        }
    }
}
