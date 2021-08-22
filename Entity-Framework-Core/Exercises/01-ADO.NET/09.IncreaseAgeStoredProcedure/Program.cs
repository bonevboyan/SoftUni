using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _09.IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ids = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            using (SqlConnection con = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                con.Open();

                foreach (int id in ids)
                {
                    SqlCommand command = new SqlCommand("EXEC usp_GetOlder @id", con);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                SqlDataReader reader = new SqlCommand("SELECT * FROM Minions", con).ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} - {reader["Age"]} old years old");
                }
            }
        }
    }
}
