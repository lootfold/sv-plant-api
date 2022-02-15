using Microsoft.AspNetCore.Mvc;
using SVPlant.Core.Interfaces;
using SVPlant.Core.Models;
using System.Collections.Generic;
using System.Net;

namespace SVPlant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantService _plantService;

        public PlantsController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Plant>), (int)HttpStatusCode.OK)]
        public IActionResult GetPlants()
        {
            return Ok(_plantService.GetPlants());
        }

        [HttpPost("{id:int}/start")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult StartWatering(int id)
        {
            _plantService.StartWatering(id);
            return Ok();
        }

        [HttpPost("{id:int}/stop")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult StopWatering(int id)
        {
            _plantService.StopWatering(id);
            return Ok();
        }
    }
}
