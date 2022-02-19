namespace SharedTrip.Services.Contracts
{
    using SharedTrip.Models.FormModels;
    using SharedTrip.Models.ViewModels;
    using System.Collections.Generic;

    public interface IUserService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterFormModel model);

        void RegisterUser(RegisterFormModel model);

        (string userId, bool isCorrect) IsLoginCorrect(LoginFormModel model);
    }
}
