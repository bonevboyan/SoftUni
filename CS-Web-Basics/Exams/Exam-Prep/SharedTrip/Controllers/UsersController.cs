namespace SharedTrip.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SharedTrip.Models.FormModels;
    using SharedTrip.Services;
    using SharedTrip.Services.Contracts;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IDbHandler dbHandler;

        public UsersController(Request request) 
            : base(request)
        {
            validator = new Validator();
            dbHandler = new DbHandler();
        }

        public Response Register()
        {
            return this.View();
        }

        [HttpPost]
        public Response Register(RegisterFormModel registerModel)
        {
            var errors = validator.ValidateRegisterUser(registerModel);

            if (errors.Count != 0)
            {
                return this.View();
                //return this.View(errors, "/Error");
            }
            dbHandler.RegisterUser(registerModel);

            return this.Redirect("/Users/Login");
        }

        public Response Login()
        {
            return this.View();
        }

        [HttpPost]
        public Response Login(LoginFormModel loginModel)
        {
            var doesUserExist = dbHandler.ValidateLoginUser(loginModel);

            if (!doesUserExist)
            {
                return this.View();
            }

            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
