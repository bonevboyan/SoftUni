namespace SharedTrip.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserTrip
    {
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public string TripId { get; set; }

        [ForeignKey(nameof(TripId))]
        public Trip Trip { get; set; }
    }
}
