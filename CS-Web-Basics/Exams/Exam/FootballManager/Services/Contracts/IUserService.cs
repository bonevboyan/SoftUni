namespace FootballManager.Services.Contracts
{
    using FootballManager.Models.FormModels;
    using FootballManager.Models.ViewModels;

    public interface IUserService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterFormModel model);

        void RegisterUser(RegisterFormModel model);

        (string userId, bool isCorrect) IsLoginCorrect(LoginFormModel model);
    }
}
