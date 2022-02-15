using Microsoft.EntityFrameworkCore;
using SVPlant.Core.Models;
using System.Collections.Generic;

namespace SVPlant.Infrastructure.Data
{
    public class SVPlantDbContext : DbContext
    {
        public SVPlantDbContext(DbContextOptions<SVPlantDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<WateringLog> WateringLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>().HasData(new List<Plant>
            {
                new Plant{Id = 1, Name = "Plant1", IsGettingWatered = false},
                new Plant{Id = 2, Name = "Plant2", IsGettingWatered = false},
                new Plant{Id = 3, Name = "Plant3", IsGettingWatered = false},
                new Plant{Id = 4, Name = "Plant4", IsGettingWatered = false},
                new Plant{Id = 5, Name = "Plant5", IsGettingWatered = false},
            });
        }
    }
}
