using SharedTrip.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class Trip
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }

        [MaxLength(GlobalConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; } = new HashSet<UserTrip>();
    }
}
