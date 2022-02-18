using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.FormModels
{
    public class RegisterFormModel
    {
        public string Username { get; set; }

        public string ConfirmPassword { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
