using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInformationSystemAPI.Controllers
{
    //Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController: ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllEmployees() {
            var getAll = await _employeesService.GetEmployees();
            return Ok(getAll);
        }

        [Route("{Id:int}")]
        [HttpGet]

        public async Task<IActionResult> GetClientInteractionById(int Id)
        {
            var employeeinteraction = await _employeesService.GetInteractionByEmployeeId(Id);
            return Ok(employeeinteraction);
        }

        [Route("addemployee")]
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeesRequestModel model)
        {
            var postemployee = await _employeesService.PostEmployee(model);
            return Ok(postemployee);
        }


        [HttpPut]
        [Route("updateemployee")]
        public async Task<IActionResult> PutEmployee([FromBody] PutEmployeesRequestModel model)
        {
            var putemployee = await _employeesService.PutEmployee(model);
            return Ok(putemployee);
        }

        [HttpDelete]
        [Route("deleteemployee")]
        public async Task DeleteEmployee(DeleteEmployeesRequestModel model)
        {

            await _employeesService.DeleteEmployee(model);

        }


    }
}
