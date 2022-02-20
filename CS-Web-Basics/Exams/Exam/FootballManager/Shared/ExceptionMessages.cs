namespace FootballManager.Shared
{
    public class ExceptionMessages
    {
        public const string InvalidUsername = "Username is requred and must be between {0} and {1} characters.";

        public const string InvalidPassword = "Password is requred and must be between {0} and {1} characters.";

        public const string InvalidEmail = "Email is requred and must be between {0} and {1} characters.";

        public const string UnmatchingPasswords = "Password and ConfirmPassword are not the same.";

        public const string UserIsTaken = "The username {0} is already taken.";

        public const string PlayerExists = "The player {0} already exists.";

        public const string PlayerDoesntExist = "The player with the id of '{0}' doesn't exists.";

        public const string InvalidPlayerName = "Player name is requred and must be between {0} and {1} characters.";

        public const string InvalidImageUrl = "Image URL is requred.";

        public const string InvalidPosition = "Position is requred and must be between {0} and {1} characters.";

        public const string InvalidSpeed = "Speed is requred and must be between {0} and {1}.";

        public const string InvalidEndurance = "Endurance is requred and must be between {0} and {1}.";

        public const string InvalidDescription = "Description is required and must be less than {0} characters.";

        public const string AlreadyContained = "Player with the id of '{0}' is already in this user's collection";
    }
}
