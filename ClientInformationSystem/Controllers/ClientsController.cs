using ApplicationCore.Entities;
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
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllClients()
        {
            var getAll = await _clientsService.GetClients();
            return Ok(getAll);
        }

        [Route("{Id:int}")]
        [HttpGet]

        public async Task<IActionResult> GetClientInteractionById(int Id) {
            var clientinteraction = await _clientsService.GetInteractionByClientId(Id);
            return Ok(clientinteraction);
        }

        [Route("addclient")]
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] ClientsRequestModel model) {
            var postclient = await _clientsService.PostClient(model);
            return Ok(postclient);
        }

        [HttpPut]
        [Route("updateclient")]
        public async Task<IActionResult> PutClient([FromBody] PutClientsRequestModel model)
        {
            var putclient = await _clientsService.PutClient(model);
            return Ok(putclient);
        }

        [HttpDelete]
        [Route("deleteclient")]
        public async Task DeleteClient(DeleteClientsRequestModel model)
        {
            
            await _clientsService.DeleteClient(model);

        }

    }
}
