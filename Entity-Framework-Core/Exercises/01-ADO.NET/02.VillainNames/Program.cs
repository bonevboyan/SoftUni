using System;
using Microsoft.Data.SqlClient;

namespace _02.VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection con = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) AS Count, v.Name AS Name FROM Villains v JOIN MinionsVillains mv ON mv.VillainId = v.Id JOIN Minions m ON m.Id = mv.MinionId GROUP BY v.Name ORDER BY Count DESC", con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int count = (int)reader["Count"];
                    string name = (string)reader["Name"];

                    Console.WriteLine($"{name} - {count}");
                }

            }
        }
    }
}
