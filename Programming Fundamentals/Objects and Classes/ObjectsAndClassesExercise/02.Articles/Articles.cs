using System;

namespace _02.Articles
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public void Edit(string newContent)
        {
            Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }
    }
    class Articles
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Article article = new Article
            {
                Title = input[0],
                Content = input[1],
                Author = input[2]
            };
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(": ");
                switch (input[0])
                {
                    case "Edit":
                        article.Edit(input[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(input[1]);
                        break;
                    case "Rename":
                        article.Rename(input[1]);
                        break;
                }
            }
            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
}
