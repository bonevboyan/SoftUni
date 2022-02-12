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

        public TripsController(Request request) : base(request)
        {
            validator = new Validator();
        }

        public Response All()
        {
            return this.View();
        }

        public Response Details(string tripId)
        {
            return this.View();
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
                return this.View(errors, "/Error");
            }

            return this.View("/Trips/All");
        }
    }
}
