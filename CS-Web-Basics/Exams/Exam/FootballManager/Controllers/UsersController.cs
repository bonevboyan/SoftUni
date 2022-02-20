namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Models.FormModels;
    using FootballManager.Models.ViewModels;
    using FootballManager.Services.Contracts;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request, IUserService userService)
            : base(request)
        {
            this.userService = userService;
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return this.View(new { User.IsAuthenticated });
        }

        [HttpPost]
        public Response Register(RegisterFormModel model)
        {
            var (isValid, errors) = userService.ValidateModel(model);

            if (!isValid)
            {
                return View(new { User.IsAuthenticated, ErrorList = errors }, "/Error");
            }

            try
            {
                userService.RegisterUser(model);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) }, "/Error");
            }
            catch (Exception)
            {
                return View(new { User.IsAuthenticated, ErrorList = new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") } }, "/Error");
            }

            return Redirect("/Users/Login");
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return this.View(new { User.IsAuthenticated });
        }

        [HttpPost]
        public Response Login(LoginFormModel loginModel)
        {
            Request.Session.Clear();

            (string userId, bool isCorrect) = userService.IsLoginCorrect(loginModel);

            if (isCorrect)
            {
                SignIn(userId);

                CookieCollection cookies = new CookieCollection();
                cookies.Add(Session.SessionCookieName,
                    Request.Session.Id);

                return Redirect("/Players/All");
            }

            return View(new { User.IsAuthenticated, ErrorList = new List<ErrorViewModel>() { new ErrorViewModel("Login incorrect") } }, "/Error");
        }

        [Authorize]
        public Response Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
