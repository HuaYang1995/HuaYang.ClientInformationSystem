using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class EmployeesService :IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IInteractionRepository _interactionRepository;

        public EmployeesService(IEmployeesRepository employeesRepository, IInteractionRepository interactionRepository)
        {
            _employeesRepository = employeesRepository;
            _interactionRepository = interactionRepository;
        }
        public async Task<List<EmployeesResponseModel>> GetEmployees() {
            var getemployees = await _employeesRepository.GetAllEmployees();

            var employeesInfo = new List<EmployeesResponseModel>();

            foreach (var employee in getemployees)
            {
                employeesInfo.Add(new EmployeesResponseModel
                {   Id = employee.Id,
                    Name = employee.Name,
                Designation =employee.Designation

                });
            }
            return employeesInfo;
        }

        public async Task<List<InteractionsResponseModel>> GetInteractionByEmployeeId(int id)
        {
            var interactions = await _interactionRepository.GetInterationsByEmployeeId(id);

            var interactionemployee = new List<InteractionsResponseModel>();

            foreach (var interaction in interactions)
            {
                interactionemployee.Add(new InteractionsResponseModel
                {
                    Id = interaction.Id,
                    IntType = interaction.IntType,
                    IntDate = interaction.IntDate,
                    Remarks = interaction.Remarks,
                    ClientName = interaction.Clients.Name
                    
                });

            }
            return interactionemployee;
        }

        public async Task<Employees> PostEmployee(EmployeesRequestModel model)
        {
            var employee = new Employees
            {
                Name = model.Name,
                Password = model.Password,
                Designation =model.Designation

            };
            var employees = await _employeesRepository.AddAsync(employee);
            return employees;

        }

        public async Task<Employees> PutEmployee(PutEmployeesRequestModel model)
        {
            var employee = new Employees
            {
                Id = model.Id,
                Name = model.Name,
                Password = model.Password,
                Designation = model.Designation

            };
            var employees = await _employeesRepository.UpdateAsync(employee);
            return employees;

        }

        public async Task DeleteEmployee(DeleteEmployeesRequestModel model)
        {
            var employee = new Employees
            {
                Id= model.Id
            };

            await _employeesRepository.DeleteAsync(employee);
        }
    }
}
