﻿namespace SMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using SMS.Shared;

    public class User
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(GlobalConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [MaxLength(GlobalConstants.PasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
