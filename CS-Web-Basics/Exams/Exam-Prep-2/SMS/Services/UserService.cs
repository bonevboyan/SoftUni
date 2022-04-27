﻿namespace SMS.Services
{
    using SMS.Data;
    using SMS.Data.Models;
    using SMS.Models.FormModels;
    using SMS.Services.Contracts;
    using SMS.Shared;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly SMSDbContext dbContext = new SMSDbContext();

        public bool LoginUser(LoginFormModel loginForm)
        {


            throw new System.NotImplementedException();
        }

        public string RegisterUser(RegisterFormModel registerFormModel)
        {
            var errors = ValidateUser(registerFormModel);

            if (errors.Length > 0)
            {
                return errors;
            }

            var newUser = new User
            {
                Username = registerFormModel.Username,
                Password = registerFormModel.Password,
                Email = registerFormModel.Email
            };

            newUser.Cart = new Cart
            {
                UserId = newUser.Id
            };

            dbContext.Users.Add(newUser);

            dbContext.SaveChanges();

            return string.Empty;
        }

        private string ValidateUser(RegisterFormModel registerFormModel)
        {
            StringBuilder sb = new StringBuilder();

            if (registerFormModel == null)
            {
                sb.AppendLine(ErrorMesages.ModelIsRequired);
            }

            if(registerFormModel.Email == null)
            {
                sb.AppendLine(ErrorMesages.EmailIsRequired);
            }

            if(registerFormModel.Username == null 
                || registerFormModel.Username.Length < GlobalConstants.UsernameMinLength 
                || registerFormModel.Username.Length > GlobalConstants.UsernameMaxLength)
            {
                sb.AppendLine(string.Format(ErrorMesages.UsernameIsRequired, GlobalConstants.UsernameMinLength, GlobalConstants.UsernameMaxLength));
            }

            if (registerFormModel.Password == null 
                || registerFormModel.Password != registerFormModel.ConfirmPassword
                || registerFormModel.Password.Length < GlobalConstants.PasswordMinLength
                || registerFormModel.Password.Length > GlobalConstants.PasswordMaxLength)
            {
                sb.AppendLine(string.Format(ErrorMesages.UsernameIsRequired, GlobalConstants.UsernameMinLength, GlobalConstants.UsernameMaxLength));
            }

            return sb.ToString();
        }

        private string 
    }
}