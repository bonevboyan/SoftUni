using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                decimal grade = decimal.Parse(Console.ReadLine());
                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<decimal> { grade });
                }
            }
            foreach (var student in students)
            {
                decimal sum = 0;
                for (int i = 0; i < student.Value.Count; i++)
                {
                    sum += student.Value[i];
                }
                student.Value[0] = sum/student.Value.Count;
            }
            students = students.OrderByDescending(o => o.Value[0]).ToDictionary(o => o.Key, o => o.Value);
            foreach (var student in students)
            {
                if (student.Value[0] >= (decimal)4.5)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value[0]:f2}");
                }
            }
        }
    }
}
