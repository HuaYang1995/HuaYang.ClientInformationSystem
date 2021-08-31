using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IEmployeesService
    {
        Task<List<EmployeesResponseModel>> GetEmployees();

        Task<List<InteractionsResponseModel>> GetInteractionByEmployeeId(int id);

        Task<Employees> PostEmployee(EmployeesRequestModel model);

        Task<Employees> PutEmployee(PutEmployeesRequestModel model);

        Task DeleteEmployee(DeleteEmployeesRequestModel model);
    }
}
