using System;

namespace _03.ExtractFile
{
    class ExtractFile
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('\\');
            string[] file = input[input.Length - 1].Split('.');
            Console.WriteLine($"File name: {file[0]}\nFile extension: {file[1]}");
        }
    }
}
