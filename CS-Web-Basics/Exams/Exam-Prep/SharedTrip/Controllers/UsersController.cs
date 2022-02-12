namespace SharedTrip.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SharedTrip.Models;
    using SharedTrip.Services;

    public class UsersController : Controller
    {
        private IValidator validator;
        private IDbHandler dbHandler;

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
        public Response Register(RegisterModel registerModel)
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
        public Response Login(LoginModel loginModel)
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
