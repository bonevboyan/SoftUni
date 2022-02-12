namespace SharedTrip.Services.Contracts
{
    using SharedTrip.Models.FormModels;

    public interface IDbHandler
    {
        bool ValidateLoginUser(LoginFormModel registerModel);

        void RegisterUser(RegisterFormModel registerModel);
    }
}
