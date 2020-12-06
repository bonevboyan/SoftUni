using System;
using System.Collections.Generic;
using System.Linq;


namespace _08.CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] input = line.Split(" -> ");
                string companyName = input[0];
                string id = input[1];
                if (companies.ContainsKey(companyName))
                {
                    if(!companies[companyName].Contains(id))
                    companies[companyName].Add(id);
                }
                else
                {
                    companies.Add(companyName, new List<string> { id });
                }
                line = Console.ReadLine();
            }
            companies = companies.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Key}");
                company.Value.Sort();
                foreach (var employee in company.Value)
                {
                    Console.WriteLine("-- " + employee);
                }
            }
        }
    }
}
