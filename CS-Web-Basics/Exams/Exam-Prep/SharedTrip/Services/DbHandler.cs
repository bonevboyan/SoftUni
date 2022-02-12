namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.FormModels;
    using SharedTrip.Services.Contracts;
    using System.Linq;

    public class DbHandler : IDbHandler
    {
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public DbHandler()
        {
            data = new ApplicationDbContext();
            passwordHasher = new PasswordHasher();
        }

        public void RegisterUser(RegisterFormModel registerModel)
        {
            var user = new User
            {
                Username = registerModel.Username,
                Password = this.passwordHasher.HashPassword(registerModel.Password),
                Email = registerModel.Email
            };

            data.Add(user);

            data.SaveChanges();
        }

        public bool ValidateLoginUser(LoginFormModel registerModel)
        {
            var hashedPassword = this.passwordHasher.HashPassword(registerModel.Password);

            var userExists = this.data
                .Users
                .Where(u => u.Username == registerModel.Username && u.Password == hashedPassword)
                .Any();

            return userExists;
        }

        
    }
}
