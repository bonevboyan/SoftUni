using Microsoft.Data.SqlClient;
using System;

namespace _06.RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                con.Open();

                SqlCommand selectNameCommand = new SqlCommand("SELECT Name FROM Villains WHERE Id = @villainId", con);
                selectNameCommand.Parameters.AddWithValue("@villainId", villainId);
                string villainName = (string)selectNameCommand.ExecuteScalar();

                if (string.IsNullOrWhiteSpace(villainName))
                {
                    Console.WriteLine("No such villain was found.");
                }

                SqlCommand deleteMVCommand = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @villainId", con);
                deleteMVCommand.Parameters.AddWithValue("@villainId", villainId);
                int releasedMinions = deleteMVCommand.ExecuteNonQuery();

                SqlCommand deleteVillainCommand = new SqlCommand("DELETE FROM Villains WHERE Id = @villainId", con);
                deleteVillainCommand.Parameters.AddWithValue("@villainId", villainId);
                deleteVillainCommand.ExecuteNonQuery();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
        }
    }
}
