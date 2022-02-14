namespace SharedTrip.Services.Contracts
{
    using SharedTrip.Models.FormModels;
    using SharedTrip.Models.ViewModels;

    public interface IDbHandler
    {
        bool ValidateLoginUser(LoginFormModel registerModel);

        void RegisterUser(RegisterFormModel registerModel);

        void AddTrips(TripFormModel tripModel);

        TripViewModel GetTrip(string id);
    }
}
