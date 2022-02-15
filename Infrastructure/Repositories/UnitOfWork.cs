using SVPlant.Core.Interfaces;
using SVPlant.Infrastructure.Data;

namespace SVPlant.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SVPlantDbContext _dbContext;

        public UnitOfWork(SVPlantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
