using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SVPlant.Models
{
    public class Plant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsGettingWatered { get; set; }

        [NotMapped]
        public DateTime? LastWatered
        {
            get
            {
                var lastlog = WateringLogs.LastOrDefault();
                return lastlog != null ? lastlog.StopTime : null;
            }
        }

        public ICollection<WateringLog> WateringLogs { get; set; }
    }
}
