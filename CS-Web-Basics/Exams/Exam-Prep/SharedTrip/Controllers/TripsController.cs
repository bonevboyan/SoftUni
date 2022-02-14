namespace SharedTrip.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SharedTrip.Models.FormModels;
    using SharedTrip.Services;
    using SharedTrip.Services.Contracts;

    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly IDbHandler dbHandler;

        public TripsController(Request request) : base(request)
        {
            validator = new Validator();
            dbHandler = new DbHandler();
        }

        public Response All()
        {
            return this.View();
        }

        public Response Details(string tripId)
        {
            var trip = dbHandler.GetTrip(tripId);
            return this.View(trip);
        }

        [HttpGet]
        public Response Add()
        {
            return this.View();
        }

        [HttpPost]
        public Response Add(TripFormModel tripModel)
        {
            var errors = validator.ValidateTrip((TripFormModel)tripModel);

            if(errors.Count != 0)
            {
                return this.View();
                //return this.View(errors, "/Error");
            }

            dbHandler.AddTrips(tripModel);

            return this.Redirect("/Trips/All");
        }
    }
}
