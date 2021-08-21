using Microsoft.Data.SqlClient;
using System;

namespace _01.InitialSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection con = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                con.Open();

                //SqlCommand createDB = new SqlCommand("CREATE DATABASE MinionsDB", con);
                //createDB.ExecuteNonQuery();

                foreach (var query in CreateTableQueries())
                {
                    new SqlCommand(query, con).ExecuteNonQuery();
                }

                foreach (var query in InsertIntoTableQueries())
                {
                    new SqlCommand(query, con).ExecuteNonQuery();
                }
            }
        }

        static string[] CreateTableQueries()
        {
            return new string[]
            {
                "CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50),CountryCode INT REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50),Age INT,TownId INT REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50),EvilnessFactorId INT REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains(MinionId INT REFERENCES Minions(Id),VillainId INT REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))"
            };


            
        }
        static string[] InsertIntoTableQueries()
        {
            return new string[]
            {
                    "INSERT INTO Countries VALUES ('Bulgaria'), ('UK'), ('USA'), ('France'), ('Poland')",
                    "INSERT INTO Towns VALUES ('Sofia', 1), ('London', 2), ('New York', 3), ('Paris', 4), ('Warsaw', 5)",
                    "INSERT INTO Minions VALUES ('Gosho', 16, 1), ('Pesho', 16, 2), ('Marin', 16, 3), ('Pencho', 16, 4), ('Ines', 16, 5)",
                    "INSERT INTO EvilnessFactors VALUES ('super good'), ('good'), ('bad'), ('evil'), ('super evil')",
                    "INSERT INTO Villains VALUES ('Gru', 1), ('Groot', 2), ('Thanos', 3), ('Cruella', 4), ('Voldemort', 5)",
                    "INSERT INTO MinionsVillains VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5)"
            };
        }
    }
}
