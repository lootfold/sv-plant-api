using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SVPlant.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SVPlant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly SVPlantDbContext _dbContext;

        public PlantsController(SVPlantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetPlants()
        {
            var plants = _dbContext.Plants.Include(p => p.WateringLogs);
            return Ok(plants);
        }

        [HttpPost("{id:int}/start")]
        public async Task<IActionResult> StartWatering(int id)
        {
            var plantInDb = await _dbContext.Plants
                .Include(p => p.WateringLogs)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (plantInDb == null)
            {
                return NotFound();
            }

            if (plantInDb.IsGettingWatered)
            {
                return BadRequest(new { Message = $"{plantInDb.Name} is already getting watered." });
            }

            if (plantInDb.LastWatered != null)
            {
                var timeDiff = DateTime.Now - plantInDb.LastWatered;
                var minutes = timeDiff.Value.TotalSeconds;
                if (minutes < 30)
                {
                    return BadRequest(new { Message = "Please wait 30 minutes before watering the plant again." });
                }
            }

            var log = new WateringLog
            {
                PlantId = id,
                StartTime = DateTime.Now,
            };
            plantInDb.IsGettingWatered = true;

            await _dbContext.WateringLogs.AddAsync(log);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{id:int}/stop")]
        public async Task<IActionResult> StopWatering(int id)
        {
            var plantInDb = await _dbContext.Plants
                .Include(p => p.WateringLogs)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (plantInDb == null)
            {
                return NotFound();
            }

            if (!plantInDb.IsGettingWatered)
            {
                return BadRequest(new { Message = $"{plantInDb.Name} is not getting watered." });
            }

            var lastLog = plantInDb.WateringLogs.LastOrDefault();
            lastLog.StopTime = DateTime.Now;

            plantInDb.IsGettingWatered = false;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
