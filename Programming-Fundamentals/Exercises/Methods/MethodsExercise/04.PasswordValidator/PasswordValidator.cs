using System;

namespace _04.PasswordValidator
{
    class PasswordValidator
    {
        public static void validatePassword(String str)
        {
            bool f = true;
            if (str.Length < 6 || str.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                f = false;
            }
            str = str.ToLower();
            int letters = 0, digits = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];

                if ((ch >= 'a' && ch <= 'z'))
                {
                    letters++;
                }
                else if (ch >= '0' && ch <= '9')
                {
                    digits++;
                }
            }
            if (letters + digits != str.Length)
            {
                Console.WriteLine("Password must consist only of letters and digits");
                f = false;
            }
            if (digits < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                f = false;
            }
            if (f)
            {
                Console.WriteLine("Password is valid");
            }
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            validatePassword(str);
        }
    }
}
