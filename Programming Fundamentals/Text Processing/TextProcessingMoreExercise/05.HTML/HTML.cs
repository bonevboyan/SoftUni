using System;
using System.Collections.Generic;

namespace _05.HTML
{
    class HTML
    {
        static void Main(string[] args)
        {
            List<string> articleContent = new List<string>();

            articleContent.Add(Console.ReadLine());
            articleContent.Add(Console.ReadLine());
            string line = Console.ReadLine();

            while (line != "end of comments")
            {
                articleContent.Add(line);
                line = Console.ReadLine();
            }

            Console.WriteLine($"<h1>\n\t{articleContent[0]}\n</h1>");
            Console.WriteLine($"<article>\n\t{articleContent[1]}\n</article>");
            for (int i = 2; i < articleContent.Count; i++)
            {
                Console.WriteLine($"<div>\n\t{articleContent[i]}\n</div>");
            }
        }
    }
}
