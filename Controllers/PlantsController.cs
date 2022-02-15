using Microsoft.AspNetCore.Mvc;
using SVPlant.Core.Interfaces;

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
        public IActionResult GetPlants()
        {
            return Ok(_plantService.GetPlants());
        }

        [HttpPost("{id:int}/start")]
        public IActionResult StartWatering(int id)
        {
            _plantService.StartWatering(id);
            return Ok();
        }

        [HttpPost("{id:int}/stop")]
        public IActionResult StopWatering(int id)
        {
            _plantService.StopWatering(id);
            return Ok();
        }
    }
}
