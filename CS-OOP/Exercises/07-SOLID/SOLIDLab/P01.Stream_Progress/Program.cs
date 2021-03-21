using P01.Stream_Progress.Contracts;
using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStreamable file = new File("StartUp.cs", 10, 1);
            Console.WriteLine(new StreamProgressInfo(file).CalculateCurrentPercent());

            IStreamable music = new Music("Sabaton", "Carolus Rex", 100, 56);
            Console.WriteLine(new StreamProgressInfo(music).CalculateCurrentPercent());
        }
    }
}
