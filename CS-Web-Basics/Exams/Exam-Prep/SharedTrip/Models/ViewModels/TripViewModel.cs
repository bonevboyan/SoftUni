namespace SharedTrip.Models.ViewModels
{
    using System;

    public class TripViewModel
    {
        public string ImagePath { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }

        public string Description { get; set; }
    }
}