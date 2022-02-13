using System;

namespace SVPlant.Models
{
    public class WateringLog
    {
        public int Id { get; set; }
        public int PlantId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? StopTime { get; set; }
    }
}
