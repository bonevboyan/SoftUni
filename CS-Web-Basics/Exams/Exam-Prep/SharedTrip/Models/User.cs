using SharedTrip.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class User
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [MaxLength(GlobalConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [MaxLength(GlobalConstants.PasswordMaxLength)]
        public string Password { get; set; }
    }
}