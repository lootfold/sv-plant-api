using SVPlant.Core.Models;
using System.Collections.Generic;

namespace SVPlant.Core.Interfaces
{
    public interface IPlantService
    {
        IEnumerable<Plant> GetPlants();
        void StartWatering(int id);
        void StopWatering(int id);
    }
}
