namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using System.Collections.Generic;

    public interface IValidator
    {
        List<string> ValidateRegisterUser(RegisterModel registerModel);
    }
}
