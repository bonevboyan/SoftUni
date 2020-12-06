using System;
using System.Collections.Generic;

namespace _05.Students2
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
    class Students2
    {
        static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach(Student student in students)
            {
                if(student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }
        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;
            foreach(Student student in students)
            {
                if(student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }
            return existingStudent;
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split();
                if (IsStudentExisting(students, tokens[0], tokens[1]))
                {
                    Student student = GetStudent(students, tokens[0], tokens[1]);

                    student.FirstName = tokens[0];
                    student.LastName = tokens[1];
                    student.Age = int.Parse(tokens[2]);
                    student.City = tokens[3];
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = tokens[0],
                        LastName = tokens[1],
                        Age = int.Parse(tokens[2]),
                        City = tokens[3]
                    };

                    students.Add(student);
                }
                line = Console.ReadLine();
            }
            string filterCity = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.City == filterCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }

        }
    }
}
