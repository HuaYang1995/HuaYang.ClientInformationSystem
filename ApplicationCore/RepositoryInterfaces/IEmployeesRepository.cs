using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IEmployeesRepository : IAsyncRepository<Employees>
    {
        Task<IEnumerable<Employees>> GetAllEmployees();

        
    }
}
