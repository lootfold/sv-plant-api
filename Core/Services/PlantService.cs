using SVPlant.Core.Exceptions;
using SVPlant.Core.Interfaces;
using SVPlant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SVPlant.Core.Services
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IWateringLogRepository _wateringLogRepository;

        public PlantService(IPlantRepository plantRepository,
                            IWateringLogRepository wateringLogRepository)
        {
            _plantRepository = plantRepository;
            _wateringLogRepository = wateringLogRepository;
        }

        public IEnumerable<Plant> GetPlants()
        {
            return _plantRepository.GetPlants();
        }

        public void StartWatering(int id)
        {
            var plantInDb = _plantRepository.GetPlantById(id);

            if (plantInDb == null)
            {
                throw new PlantNotFoundException(id);
            }

            if (plantInDb.IsGettingWatered)
            {
                throw new ServiceException($"{plantInDb.Name} is already getting watered.");
            }

            if (plantInDb.LastWatered != null)
            {
                var timeDiff = DateTime.Now - plantInDb.LastWatered;
                var minutes = timeDiff.Value.TotalSeconds;
                if (minutes < 30)
                {
                    throw new ServiceException("Please wait 30 seconds before watering the plant again.");
                }
            }

            plantInDb.IsGettingWatered = true;
            var log = new WateringLog
            {
                PlantId = id,
                StartTime = DateTime.Now,
            };

            _plantRepository.UpdatePlant(plantInDb);
            _wateringLogRepository.Add(log);
        }

        public void StopWatering(int id)
        {
            var plantInDb = _plantRepository.GetPlantById(id);

            if (plantInDb == null)
            {
                throw new PlantNotFoundException(id);
            }

            if (!plantInDb.IsGettingWatered)
            {
                throw new ServiceException($"{plantInDb.Name} is not getting watered.");
            }

            var lastLog = plantInDb.WateringLogs.LastOrDefault();
            lastLog.StopTime = DateTime.Now;

            plantInDb.IsGettingWatered = false;

            _plantRepository.UpdatePlant(plantInDb);
            _wateringLogRepository.Update(lastLog);
        }
    }
}
