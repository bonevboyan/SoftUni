namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Models.FormModels;
    using FootballManager.Models.ViewModels;
    using FootballManager.Services.Contracts;
    using System;

    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(Request request, IPlayerService playerService) : base(request)
        {
            this.playerService = playerService;
        }

        [Authorize]
        public Response Add() => View(new { User.IsAuthenticated });

        [HttpPost]
        [Authorize]
        public Response Add(PlayerFormModel model)
        {
            var (isValid, errors) = playerService.ValidateModel(model);

            if (!isValid)
            {
                return View(new { User.IsAuthenticated, errors }, "/Error");
            }

            try
            {
                playerService.AddPlayer(model, User.Id);
            }
            catch (Exception)
            {
                return View(new { User.IsAuthenticated, errors = new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") } }, "/Error");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<PlayerViewModel> players = playerService.GetAllPlayers();

            return View(new { User.IsAuthenticated, players });
        }

        [Authorize]
        public Response Collection()
        {
            IEnumerable<PlayerViewModel> players = playerService.GetOwnPlayers(User.Id);

            return View(new { User.IsAuthenticated, players });
        }

        [Authorize]
        public Response AddToCollection(string playerId)
        {
            try
            {
                playerService.AddToCollection(User.Id, playerId);
            }
            catch (ArgumentException aex)
            {
                return View(new { User.IsAuthenticated, errors = new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) } }, "/Error");
            }
            catch (Exception)
            {
                return View(new { User.IsAuthenticated, errors = new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") } }, "/Error");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response RemoveFromCollection(string playerId)
        {
            try
            {
                playerService.RemoveFromCollection(User.Id, playerId);
            }
            catch (ArgumentException aex)
            {
                return View(new { User.IsAuthenticated, errors = new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) } }, "/Error");
            }
            catch (Exception)
            {
                return View(new { User.IsAuthenticated, errors = new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") } }, "/Error");
            }

            return Redirect("/Players/Collection");
        }
    }
}
