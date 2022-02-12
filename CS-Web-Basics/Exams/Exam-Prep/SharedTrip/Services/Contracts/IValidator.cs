namespace SharedTrip.Services.Contracts
{
    using SharedTrip.Models.FormModels;
    using System.Collections.Generic;

    public interface IValidator
    {
        List<string> ValidateRegisterUser(RegisterFormModel registerModel);

        List<string> ValidateTrip(TripFormModel tripModel);
    }
}
