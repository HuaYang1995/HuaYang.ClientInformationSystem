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
    public class EmployeesRepository : EfRepository<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(ClientInfoSystemDbContext dbContext) : base(dbContext) { 

        }

        public async Task<IEnumerable<Employees>> GetAllEmployees()
        {
            var getEmployees = await _dbContext.Employee.ToListAsync();

            return getEmployees;
        }
    }
}
