using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songQueue = new Queue<string>(Console.ReadLine().Split(", "));
            while (songQueue.Count > 0)
            {
                string command = Console.ReadLine();
                if (command.Contains("Play"))
                {
                    songQueue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string song = command.Substring(4, command.Length - 4);
                    if (songQueue.Contains(song))
                    {
                        Console.WriteLine(song + " is already contained!");
                    }
                    else
                    {
                        songQueue.Enqueue(song);
                    }
                }
                else if (command.Contains("Show"))
                {
                    List<string> songList = songQueue.ToList();
                    Console.WriteLine(string.Join(", ", songList));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
