namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models;
    using System.Linq;

    public class DbHandler : IDbHandler
    {
        private ApplicationDbContext data;
        private IPasswordHasher passwordHasher;

        public DbHandler()
        {
            data = new ApplicationDbContext();
            passwordHasher = new PasswordHasher();
        }

        public void RegisterUser(RegisterModel registerModel)
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

        public bool ValidateLoginUser(LoginModel registerModel)
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
