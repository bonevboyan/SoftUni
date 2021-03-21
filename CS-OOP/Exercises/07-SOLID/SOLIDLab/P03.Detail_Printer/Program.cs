using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("Gogi");
            Employee manager = new Manager("Pesho", new[] { "word", "excel", "pp" });

            DetailsPrinter detailsPrinter = new DetailsPrinter(new List<Employee>(new[] { employee, manager }));

            Console.WriteLine(detailsPrinter.PrintDetails());
        }
    }
}
