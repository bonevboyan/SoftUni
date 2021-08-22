using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection con = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT Name FROM Minions", con);
                SqlDataReader reader = command.ExecuteReader();

                List<string> names = new List<string>();
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    names.Add(name);
                }

                for (int i = 0; i < names.Count / 2; i++)
                {
                    if(names[i] != names[names.Count - 1 - i])
                    {
                        Console.WriteLine(names[i]);
                        Console.WriteLine(names[names.Count - 1 - i]);
                    }
                    else
                    {
                        Console.WriteLine(names[names.Count / 2]);
                    }
                }
            }
        }
    }
}
