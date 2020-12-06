using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class StudentInfo
    {
        public string Language { get; set; }
        public decimal Points { get; set; }
        public bool isBanned { get; set; }
        public bool isShown { get; set; }

    }
    class SoftUniExamResults
    {
        static void Main(string[] args)
        {
            Dictionary<string, StudentInfo> students = new Dictionary<string, StudentInfo>();
            string line = Console.ReadLine();
            while (line != "exam finished")
            {
                string[] input = line.Split('-');
                string name = input[0];
                if (input[1] != "banned") {
                    string language = input[1];
                    decimal points = decimal.Parse(input[2]);
                    if (!students.ContainsKey(name))
                    {
                        students.Add(name, new StudentInfo { Language = language, Points = points, isBanned = false });
                        students[name].isShown = true;
                    }
                    else
                    {
                        if (students[name].Points < points)
                        {
                            students[name].Points = points;
                        }
                        students.Add(name + " ", new StudentInfo { Language = language, Points = points, isBanned = false });
                    }
                }
                else
                {
                    students[name].isBanned = true;
                }

                line = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var student in students.OrderByDescending(o => o.Value.Points).ThenBy(o => o.Key))
            {
                if (student.Value.isShown && !student.Value.isBanned)
                {
                    Console.WriteLine($"{student.Key} | {student.Value.Points:f0}");
                }
            }
            Console.WriteLine("Submissions:");
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            foreach (var student in students)
            {
                if (submissions.ContainsKey(student.Value.Language))
                {
                    submissions[student.Value.Language]++;
                }
                else
                {
                    submissions.Add(student.Value.Language, 1);
                }
            }
            foreach (var submission in submissions.OrderByDescending(o => o.Value).ThenBy(o => o.Key))
            {
                Console.WriteLine(submission.Key + " - " + submission.Value);
            }
        }
    }
}
