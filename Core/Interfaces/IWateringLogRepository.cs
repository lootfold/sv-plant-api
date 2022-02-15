using SVPlant.Core.Models;

namespace SVPlant.Core.Interfaces
{
    public interface IWateringLogRepository
    {
        void Add(WateringLog wateringLog);
        void Update(WateringLog lastLog);
    }
}
