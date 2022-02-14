namespace SharedTrip.Services
{
    using SharedTrip.Models.FormModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Shared;
    using SharedTrip.Services.Contracts;
    using System;
    using System.Globalization;

    public class Validator : IValidator
    {
        public List<string> ValidateRegisterUser(RegisterFormModel registerModel)
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

        public List<string> ValidateTrip(TripFormModel tripModel)
        {
            var errors = new List<string>();

            if (tripModel.StartPoint == null)
            {
                errors.Add($"Start Point is empty.");
            }

            if (tripModel.EndPoint == null)
            {
                errors.Add($"End Point is empty.");
            }

            if (!DateTime.TryParseExact(tripModel.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime date))
            {
                errors.Add($"Departure Time is invalid.");
            }

            int seats;
            bool canParse = int.TryParse(tripModel.Seats, out seats);

            if (!canParse || seats < GlobalConstants.TripSeatsMinValue || seats > GlobalConstants.TripSeatsMaxValue)
            {
                    errors.Add($"Value of seats '{tripModel.Seats}' is not valid.");
            }

            if (tripModel.Description == null)
            {
                errors.Add($"Description is invalid.");
            }

            return errors;
        }
    }
}
