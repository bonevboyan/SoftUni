using System;

namespace _05.Messages
{
    class Messages
    {
        static void Main(string[] args)
        {
            int numbersOfPush = int.Parse(Console.ReadLine());

            String message = "";

            for (int i = 0; i < numbersOfPush; i++)
            {
                String digits = Console.ReadLine();
                int digitLength = digits.Length;
                char oneDigit = digits[0];
                int mainDigit = (int)char.GetNumericValue(oneDigit);
                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset = (mainDigit - 2) * 3 + 1;
                }
                int letterIndex = offset + digitLength - 1;
                int letterCode = letterIndex + 97;


                char letter = (char)letterCode;
                if (mainDigit == 0)
                {
                    letter = (char)(mainDigit + 32);
                }
                message += letter;


            }
            Console.WriteLine(message);
        }
    }
}
