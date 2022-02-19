namespace SharedTrip.Services.Contracts
{
    using SharedTrip.Models.ViewModels;
    using System.Collections.Generic;


    public interface ITripService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(TripViewModel model);

        void AddTrip(TripViewModel model);

        IEnumerable<TripListViewModel> GetAllTrips();

        TripDetailsViewModel GetTripDetails(string tripId);

        void AddUserToTrip(string tripId, string id);
    }
}
