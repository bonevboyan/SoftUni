using Microsoft.Data.SqlClient;
using System;

namespace _04.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Minion: ");
            string[] minionInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string townName = minionInfo[2];

            Console.Write("Villain: ");
            string[] villainInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string villainName = villainInfo[0];

            using (SqlConnection con = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                con.Open();

                SqlTransaction sqlTran = con.BeginTransaction();

                try
                {
                    if (AddTownIfItDoesNotExist(con, townName))
                    {
                        Console.WriteLine($"Town {townName} was added to the database.");
                    }

                    if (AddVillainIfItDoesNotExist(con, villainName))
                    {
                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }

                    InsertMinion(con, minionName, minionAge, townName);

                    AddMinionToVillain(con, minionName, villainName);

                    sqlTran.Commit();
                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
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
                insertCommand.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        static bool AddVillainIfItDoesNotExist(SqlConnection con, string villainName)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Villains WHERE Name = @name", con);
            command.Parameters.AddWithValue("@name", villainName);
            if ((int)command.ExecuteScalar() == 0)
            {
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Villains VALUES (@name, NULL)", con);
                insertCommand.Parameters.AddWithValue("@name", villainName);
                insertCommand.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        static void InsertMinion(SqlConnection con, string minionName, int age, string townName)
        {
            SqlCommand idCommand = new SqlCommand("SELECT Id FROM Towns WHERE Name = @name", con);
            idCommand.Parameters.AddWithValue("@name", townName);
            int townId = (int)idCommand.ExecuteScalar();
            
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Minions (Name, Age, TownId) VALUES (@minionName, @age, @townId)", con);
            insertCommand.Parameters.AddWithValue("@minionName", minionName);
            insertCommand.Parameters.AddWithValue("@age", age);
            insertCommand.Parameters.AddWithValue("@townId", townId);
            insertCommand.ExecuteNonQuery();
        }
        static void AddMinionToVillain(SqlConnection con, string minionName, string villainName)
        {
            SqlCommand minionIdCommand = new SqlCommand("SELECT Id FROM Minions WHERE Name = @minionName", con);
            minionIdCommand.Parameters.AddWithValue("@minionName", minionName);
            int minionId = (int)minionIdCommand.ExecuteScalar();

            SqlCommand villainIdCommand = new SqlCommand("SELECT Id FROM Villains WHERE Name = @villainName", con);
            villainIdCommand.Parameters.AddWithValue("@villainName", villainName);
            int villainId = (int)villainIdCommand.ExecuteScalar();

            SqlCommand insertCommand = new SqlCommand("INSERT INTO MinionsVillains VALUES (@minionId, @villainId)", con);
            insertCommand.Parameters.AddWithValue("@minionId", minionId);
            insertCommand.Parameters.AddWithValue("@villainId", villainId);
            insertCommand.ExecuteNonQuery();
        }
    }
}
