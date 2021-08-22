using Microsoft.Data.SqlClient;
using System;

namespace _04.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];

            string[] villainInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string villainName = villainInfo[0];

            using (SqlConnection con = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                con.Open();
                if(AddTownIfItDoesNotExist(con, townName))
                {
                    Console.WriteLine($"Town {townName} was added to the database.");
                }
            }

        }
        static bool AddTownIfItDoesNotExist(SqlConnection con, string townName)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Towns WHERE Name = @name", con);
            command.Parameters.AddWithValue("@name", townName);
            if ((int)command.ExecuteScalar() == 0)
            {
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Towns VALUES (@name, NULL)", con);
                insertCommand.Parameters.AddWithValue("@name", townName);
                Console.WriteLine(insertCommand.ExecuteNonQuery());
                return true;
            }
            return false;
        }
    }
}
