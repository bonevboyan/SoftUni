namespace FootballManager.Services.Contracts
{
    using FootballManager.Models.FormModels;
    using FootballManager.Models.ViewModels;

    public interface IPlayerService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(PlayerFormModel model);

        void AddPlayer(PlayerFormModel model, string usedId);

        void AddToCollection(string userId, string playerId);

        void RemoveFromCollection(string userId, string playerId);

        IEnumerable<PlayerViewModel> GetAllPlayers();

        IEnumerable<PlayerViewModel> GetOwnPlayers(string userId);
    }
}
