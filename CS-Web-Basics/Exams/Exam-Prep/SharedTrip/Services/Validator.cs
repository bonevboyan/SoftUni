namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Shared;

    public class Validator : IValidator
    {
        public List<string> ValidateRegisterUser(RegisterModel registerModel)
        {
            var errors = new List<string>();

            if (registerModel.Username == null || registerModel.Username.Length < GlobalConstants.UsernameMinLength || registerModel.Username.Length > GlobalConstants.UsernameMaxLength)
            {
                errors.Add($"Username '{registerModel.Username}' is not valid. It must be between {GlobalConstants.UsernameMinLength} and {GlobalConstants.UsernameMaxLength} characters long.");
            }

            if (registerModel.Email == null || !Regex.IsMatch(registerModel.Email, GlobalConstants.EmailRegex))
            {
                errors.Add($"Email '{registerModel.Email}' is not a valid e-mail address.");
            }

            if (registerModel.Password == null || registerModel.Password.Length < GlobalConstants.PasswordMinLength || registerModel.Password.Length > GlobalConstants.PasswordMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {GlobalConstants.PasswordMinLength} and {GlobalConstants.PasswordMaxLength} characters long.");
            }

            if (registerModel.Password != null && registerModel.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }
    }
}
