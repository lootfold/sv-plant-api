using SVPlant.Core.Interfaces;
using SVPlant.Core.Models;
using SVPlant.Infrastructure.Data;

namespace SVPlant.Infrastructure.Repositories
{
    public class WateringLogRepository : IWateringLogRepository
    {
        private readonly SVPlantDbContext _dbContext;

        public WateringLogRepository(SVPlantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(WateringLog wateringLog)
        {
            _dbContext.WateringLogs.Add(wateringLog);
        }

        public void Update(WateringLog lastLog)
        {
            _dbContext.WateringLogs.Update(lastLog);
        }
    }
}
