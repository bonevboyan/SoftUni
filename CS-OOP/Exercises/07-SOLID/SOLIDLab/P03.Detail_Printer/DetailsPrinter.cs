using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public string PrintDetails()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Employee employee in this.employees)
            {
                sb.Append(employee.ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}
