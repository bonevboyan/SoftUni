using System;
using System.Collections.Generic;
using System.Linq;
/*4
Lakia Eason 3,90
Prince Messing 5,49
Akiko Segers 4,85
Rocco Erben 6,00
*/
namespace _04.Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Grade { get; set; }
    }
    class Students
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                Student article = new Student
                {
                    FirstName = input[0],
                    LastName = input[1],
                    Grade = decimal.Parse(input[2])
                };
                students.Add(article);
            }
            students = students.OrderBy(o => o.Grade).ToList();
            students.Reverse();
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{students[i].FirstName} {students[i].LastName}: {students[i].Grade:f2}");
            }

        }
    }
}
