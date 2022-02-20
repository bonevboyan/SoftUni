namespace FootballManager.Services
{
    using FootballManager.Data;
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;
    using FootballManager.Models.FormModels;
    using FootballManager.Models.ViewModels;
    using FootballManager.Services.Contracts;
    using FootballManager.Shared;
    using System.Collections.Generic;

    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;

        public PlayerService(IRepository repo)
        {
            this.repo = repo;
        }

        public void AddPlayer(PlayerFormModel model, string usedId)
        {
            var aas = GetPlayerByUsername(model.FullName);
            
            var playerExists = aas != null;

            if (playerExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerExists, model.FullName));
            }

            Player player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = (byte) model.Speed,
                Endurance = (byte) model.Endurance,
                Description = model.Description
            };

            repo.Add(player);

            repo.SaveChanges();

            AddToCollection(usedId, player.Id);
        }

        public void AddToCollection(string userId, string playerId)
        {
            var playerExists = GetPlayerById(playerId) != null;

            if (!playerExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerDoesntExist, playerId));
            }

            var isInCollection =  repo.All<UserPlayer>()
                .FirstOrDefault(x => x.UserId == userId && x.PlayerId == playerId);

            if (isInCollection != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyContained, playerId));
            }

            UserPlayer userPlayer = new UserPlayer()
            {
                UserId = userId,
                PlayerId = playerId
            };

            repo.Add(userPlayer);
            repo.SaveChanges();

        }

        public void RemoveFromCollection(string userId, string playerId)
        {
            var playerExists = GetPlayerById(playerId) != null;

            if (!playerExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerDoesntExist, playerId));
            }

            var userPlayer = repo.All<UserPlayer>()
                .FirstOrDefault(x => x.UserId == userId && x.PlayerId == playerId);

            repo.Remove(userPlayer);

            repo.SaveChanges();
        }

        public IEnumerable<PlayerViewModel> GetAllPlayers()
        {
            return repo.All<Player>()
                .Select(x => new PlayerViewModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    FullName = x.FullName,
                    Position = x.Position,
                    Speed = x.Speed,
                    Endurance = x.Endurance
                });

        }

        public IEnumerable<PlayerViewModel> GetOwnPlayers(string userId)
        {
            return repo.All<Player>()
                .Where(x => x.UserPlayers.Any(x => x.UserId == userId))
                .Select(x => new PlayerViewModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    FullName = x.FullName,
                    Position = x.Position,
                    Speed = x.Speed,
                    Endurance = x.Endurance
                });
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(PlayerFormModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.FullName == null || model.FullName.Length < GlobalConstants.PlayerNameMinLength || model.FullName.Length > GlobalConstants.PlayerNameMaxLength)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(string.Format(ExceptionMessages.InvalidPlayerName, GlobalConstants.PlayerNameMinLength, GlobalConstants.PlayerNameMaxLength)));
            }

            if(model.ImageUrl == null)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(ExceptionMessages.InvalidImageUrl));
            }

            if (model.Position == null || model.Position.Length < GlobalConstants.PlayerPositionMinLength || model.Position.Length > GlobalConstants.PlayerPositionMaxLength)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(string.Format(ExceptionMessages.InvalidPosition, GlobalConstants.PlayerPositionMinLength, GlobalConstants.PlayerPositionMaxLength)));
            }

            if (model.Speed < GlobalConstants.PlayerSpeedMinValue || model.Speed > GlobalConstants.PlayerSpeedMaxValue)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(string.Format(ExceptionMessages.InvalidSpeed, GlobalConstants.PlayerSpeedMinValue, GlobalConstants.PlayerSpeedMaxValue)));
            }

            if (model.Endurance < GlobalConstants.PlayerEnduranceMinValue || model.Speed > GlobalConstants.PlayerEnduranceMaxValue)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(string.Format(ExceptionMessages.InvalidEndurance, GlobalConstants.PlayerEnduranceMinValue, GlobalConstants.PlayerEnduranceMaxValue)));
            }

            if(model.Description == null || model.Description.Length > GlobalConstants.PlayerDescriptionMaxLength)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(string.Format(ExceptionMessages.InvalidDescription, GlobalConstants.PlayerDescriptionMaxLength)));
            }

            return (isValid, errors);
        }

        private Player GetPlayerByUsername(string name)
        {
            return repo.All<Player>().FirstOrDefault(u => u.FullName == name);
        }

        private Player GetPlayerById(string id)
        {
            return repo.All<Player>().FirstOrDefault(u => u.Id == id);
        }
    }
}
