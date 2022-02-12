namespace SharedTrip.Services
{
    using SharedTrip.Models;

    public interface IDbHandler
    {
        bool ValidateLoginUser(LoginModel registerModel);

        void RegisterUser(RegisterModel registerModel);
    }
}
