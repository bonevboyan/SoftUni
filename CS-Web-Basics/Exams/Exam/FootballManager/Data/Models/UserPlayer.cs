namespace FootballManager.Data.Models
{
    public class UserPlayer
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public string PlayerId { get; set; }

        public Player Player { get; set; }
    }
}