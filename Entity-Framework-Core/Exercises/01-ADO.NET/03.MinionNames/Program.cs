using Microsoft.Data.SqlClient;
using System;

namespace _03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string villainName = Console.ReadLine();
            using (SqlConnection con = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT  m.Name, m.Age,DENSE_RANK() OVER (ORDER BY m.Name) AS Rank FROM Villains v JOIN MinionsVillains mv ON mv.VillainId = v.Id JOIN Minions m ON m.Id = mv.MinionId WHERE v.Name = @name ORDER BY m.Name", con);
                command.Parameters.AddWithValue("name", villainName);

                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Villain: {villainName}");
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        int age = (int)reader["Age"];
                        string name = (string)reader["Name"];
                        int rank = Int32.Parse(reader["Rank"].ToString());

                        Console.WriteLine($"{rank}. {name} {age}");
                    }
                }
                else
                {
                    Console.WriteLine("(no minions)");
                }
            }
        }
    }
}
