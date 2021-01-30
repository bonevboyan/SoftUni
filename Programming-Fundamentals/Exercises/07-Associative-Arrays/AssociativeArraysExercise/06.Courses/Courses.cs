using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] input = line.Split(" : ");
                string courseName = input[0];
                string studentName = input[1];
                if (courses.ContainsKey(courseName))
                {
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses.Add(courseName, new List<string> { studentName });
                }
                line = Console.ReadLine();
            }
            courses = courses.OrderByDescending(o => o.Value.Count).ToDictionary(o => o.Key, o => o.Value);
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                course.Value.Sort();
                foreach (var student in course.Value)
                {
                    Console.WriteLine("-- " + student);
                }
            }
        }
    }
}
