using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddNewAddressToEmployee(new SoftUniContext()));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            context.Employees.Select(x => 
                new
                {
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                }).ToList().ForEach(x => 
                {
                    sb.AppendLine($"{x.FirstName} {x.LastName} {x.MiddleName} {x.JobTitle} {x.Salary:f2}");
                });

            return sb.ToString();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            context.Employees
                .Where(x => x.Salary > 50000)
                .Select(x =>
                new
                {
                    x.FirstName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ToList().ForEach(x =>
                {
                    sb.AppendLine($"{x.FirstName} - {x.Salary:f2}");
                });

            return sb.ToString();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x =>
                new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList().ForEach(x =>
                {
                    sb.AppendLine($"{x.FirstName} {x.LastName} from {x.DepartmentName} - ${x.Salary:f2}");
                });

            return sb.ToString();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var adress = new Address { AddressText = "Vitoshka 15", TownId = 4 };

            var employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            employee.Address = adress;

            context.SaveChanges();

            context.Employees
                .Select(x =>
                new
                {
                    x.AddressId,
                    Adress = x.Address.AddressText
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList()
                .ForEach(x =>
                {
                    sb.AppendLine($"{x.Adress}");
                });

            return sb.ToString();
        }
    }
}
