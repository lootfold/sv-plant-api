using Microsoft.EntityFrameworkCore;
using SVPlant.Core.Interfaces;
using SVPlant.Core.Models;
using SVPlant.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace SVPlant.Infrastructure.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly SVPlantDbContext _dbContext;

        public PlantRepository(SVPlantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Plant> GetPlants()
        {
            return _dbContext.Plants.Include(p => p.WateringLogs);
        }

        public Plant GetPlantById(int id)
        {
            return _dbContext.Plants
                    .Include(p => p.WateringLogs)
                    .SingleOrDefault(p => p.Id == id);
        }

        public void UpdatePlant(Plant plant)
        {
            _dbContext.Plants.Update(plant);
            _dbContext.SaveChanges();
        }
    }
}
