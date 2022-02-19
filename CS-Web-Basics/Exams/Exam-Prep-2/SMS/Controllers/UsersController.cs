namespace SMS.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Models.FormModels;
    using SMS.Services;

    public class UsersController : Controller
    {
        private UserService userService;

        public UsersController(Request request) : base(request)
        {
            userService = new UserService();
        }

        public Response Login()
        {
            return this.View(new { IsAuthenticated = User.IsAuthenticated });
        }

        [HttpPost]
        public Response Login(LoginFormModel loginFormModel)
        {

            return this.View(new { IsAuthenticated = User.IsAuthenticated });
        }

        public Response Register()
        {
            return this.View(new { IsAuthenticated = User.IsAuthenticated });
        }

        [HttpPost]
        public Response Register(RegisterFormModel registerFormModel)
        {
            var errors = userService.RegisterUser(registerFormModel);

            if(errors.Length > 0)
            {
                return this.View(new { IsAuthenticated = User.IsAuthenticated, ErrorMessage = errors }, "/Error");
            }

            return this.Redirect("/Home/Index");
        }
    }
}
