using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
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
    public class InteractionsController : Controller
    {
        private readonly IInteractionsService _interactionsService;

        public InteractionsController(IInteractionsService interactionsService)
        {
            _interactionsService = interactionsService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllInteractions()
        {
            var getAll = await _interactionsService.GetInteractions();
            return Ok(getAll);
        }

        [HttpPost]
        [Route("addinteraction")]
        public async Task<IActionResult> PostInteraction([FromBody] InteractionsRequestModel model)
        {
            var postinteraction = await _interactionsService.PostInteraction(model);
            return Ok(postinteraction);
        }


        [HttpPut]
        [Route("updateinteraction")]
        public async Task<IActionResult> PutInteraction([FromBody] PutInteractionsRequestModel model)
        {
            var putinteraction = await _interactionsService.PutInteraction(model);
            return Ok(putinteraction);
        }

        [HttpDelete]
        [Route("deleteinteraction")]
        public async Task DeleteInteraction(DeleteInteractionsRequestModel model)
        {

            await _interactionsService.DeleteInteraction(model);

        }




    }
}
