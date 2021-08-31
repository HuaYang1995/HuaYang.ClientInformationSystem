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

        public class ClientsRepository : EfRepository<Clients>, IClientsRepository
        {
            public ClientsRepository(ClientInfoSystemDbContext dbContext) : base(dbContext)
            {

            }

            public async Task<IEnumerable<Clients>> GetAllClients()
            {
            var getclients = await _dbContext.Client.ToListAsync();

                return getclients;
            }


        }
  
}
