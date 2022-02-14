namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.FormModels;
    using SharedTrip.Models.ViewModels;
    using SharedTrip.Services.Contracts;
    using System;
    using System.Globalization;
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

        public void AddTrips(TripFormModel tripModel)
        {
            var trip = new Trip
            {
                StartPoint = tripModel.StartPoint,
                EndPoint = tripModel.EndPoint,
                Description = tripModel.Description,
                Seats = int.Parse(tripModel.Seats),
                ImagePath = tripModel.ImagePath,
                DepartureTime = DateTime.ParseExact(
                    tripModel.DepartureTime,
                    "dd.MM.yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None)
            };

            data.Trips.Add(trip);

            data.SaveChanges();
        }

        public TripViewModel GetTrip(string id)
        {
            var trip = data.Trips.Where(x => x.Id == id)
                .Select(x => new TripViewModel
                {
                    ImagePath = x.ImagePath,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = (DateTime)x.DepartureTime,
                    Seats = x.Seats,
                    Description = x.Description
                })
                .FirstOrDefault();

            return trip;
        }

        public void RegisterUser(RegisterFormModel registerModel)
        {
            var user = new User
            {
                Username = registerModel.Username,
                Password = this.passwordHasher.HashPassword(registerModel.Password),
                Email = registerModel.Email
            };

            data.Users.Add(user);

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
