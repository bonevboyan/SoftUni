using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the country: ");
            string country = Console.ReadLine();

            using (SqlConnection con = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT t.Name FROM Countries c JOIN Towns AS t  ON t.CountryCode = c.id WHERE c.Name = @country", con);

                command.Parameters.AddWithValue("@country", country);
                SqlDataReader reader = command.ExecuteReader();

                List<string> townNames = new List<string>();
                while (reader.Read())
                {
                    string town = (string)reader["Name"];
                    townNames.Add(town.ToUpper());
                }

                if (townNames.Count != 0)
                {
                    Console.WriteLine($"{townNames.Count} town names were affected.");
                    Console.WriteLine($"[{string.Join(", ", townNames)}]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
        }
    }
}
