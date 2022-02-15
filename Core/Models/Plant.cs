using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SVPlant.Core.Models
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
                return WateringLogs
                        .Where(w => w.StopTime != null)
                        .Select(w => w.StopTime)
                        .LastOrDefault();
            }
        }

        public ICollection<WateringLog> WateringLogs { get; set; }
    }
}
