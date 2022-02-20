namespace FootballManager.Services
{
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;
    using FootballManager.Models.FormModels;
    using FootballManager.Models.ViewModels;
    using FootballManager.Services.Contracts;
    using FootballManager.Shared;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public (string userId, bool isCorrect) IsLoginCorrect(LoginFormModel model)
        {
            bool isCorrect = false;
            string userId = String.Empty;

            var user = GetUserByUsername(model.Username);

            if (user != null)
            {
                isCorrect = user.Password == HashPassword(model.Password);
            }

            if (isCorrect)
            {
                userId = user.Id;
            }

            return (userId, isCorrect);
        }

        public void RegisterUser(RegisterFormModel model)
        {
            var userExists = GetUserByUsername(model.Username) != null;

            if (userExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.UserIsTaken, model.Username));
            }

            User user = new User()
            {
                Email = model.Email,
                Username = model.Username,
                Password = HashPassword(model.Password)
            };

            repo.Add(user);
            repo.SaveChanges();
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterFormModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.Username == null || model.Username.Length < GlobalConstants.UsernameMinLength || model.Username.Length > GlobalConstants.UsernameMaxLength)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(string.Format(ExceptionMessages.InvalidUsername, GlobalConstants.UsernameMinLength, GlobalConstants.UsernameMaxLength)));
            }

            if (model.Email == null || model.Email.Length < GlobalConstants.EmailMinLength || model.Email.Length > GlobalConstants.EmailMaxLength)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(string.Format(ExceptionMessages.InvalidEmail, GlobalConstants.EmailMinLength, GlobalConstants.EmailMaxLength)));
            }

            if (model.Password == null || model.Password.Length < GlobalConstants.PasswordMinLength || model.Password.Length > GlobalConstants.PasswordMaxLength)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(string.Format(ExceptionMessages.InvalidPassword, GlobalConstants.PasswordMinLength, GlobalConstants.PasswordMaxLength)));
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(ExceptionMessages.UnmatchingPasswords));
            }

            return (isValid, errors);
        }

        private static string HashPassword(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }

        private User GetUserByUsername(string username)
        {
            return repo.All<User>().FirstOrDefault(u => u.Username == username);
        }
    }
}
