namespace FootballManager.Data.Models
{
    using FootballManager.Shared;
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(GlobalConstants.PlayerNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayerPositionMaxLength)]
        public string Position { get; set; }

        [Required]
        public byte Speed { get; set; }

        [Required]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayerDescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new HashSet<UserPlayer>();
    }
}
