using SVPlant.Core.Models;
using System.Collections.Generic;

namespace SVPlant.Core.Interfaces
{
    public interface IPlantRepository
    {
        IEnumerable<Plant> GetPlants();
        Plant GetPlantById(int id);
    }
}
