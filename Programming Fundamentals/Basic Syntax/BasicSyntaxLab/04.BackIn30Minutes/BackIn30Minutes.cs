using System;

namespace _04.BackIn30Minutes
{
    class BackIn30Minutes
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());

            minute += 30;
            if (minute >= 60)
            {
                minute -= 60;
                hour += 1;
                if (hour == 24) hour = 0;
            }
            Console.WriteLine($"{hour}:{minute:D2}");
        }
    }
}