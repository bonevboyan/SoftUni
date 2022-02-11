using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Shared
{
    public static class GlobalConstants
    {
        public const int UsernameMinLength = 5;

        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 64;

        public const int PasswordMaxLength = 64;

        public const int TripSeatsMinValue = 2;

        public const int TripSeatsMaxValue = 6;

        public const int DescriptionMaxLength = 80;
    }
}
