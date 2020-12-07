using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
    class Articles2
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article article = new Article
                {
                    Title = input[0],
                    Content = input[1],
                    Author = input[2]
                };
                articles.Add(article);

            }
            string str = Console.ReadLine();
            switch (str)
            {
                case "title":
                    articles = articles.OrderBy(o => o.Title).ToList();
                    break;
                case "author":
                    articles = articles.OrderBy(o => o.Author).ToList();
                    break;
                case "content":
                    articles = articles.OrderBy(o => o.Content).ToList();
                    break;
            }
            for (int i = 0; i < articles.Count; i++)
            {
                Console.WriteLine($"{articles[i].Title} - {articles[i].Content}: {articles[i].Author}");
            }
        }
    }
}
