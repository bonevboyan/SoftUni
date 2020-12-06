using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
    class TeamworkProjects
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>(n);
            for (int i = 0; i < n; i++) {
                string[] input = Console.ReadLine().Split("-");
                string creator = input[0];
                string teamName = input[1];
                for (int j = 0; j < teams.Count; j++)
                {
                    if (creator == teams[j].Creator)
                    {
                        Console.WriteLine($"{creator} cannot create another team!");
                        goto nextCycle;
                    }
                    if (teamName == teams[j].Name)
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                        goto nextCycle;
                    }
                }
                Team team = new Team
                {
                    Name = teamName,
                    Creator = creator,
                    Members = new List<string>()
                };
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            nextCycle:;
            }
            string line = Console.ReadLine();
            bool f = false, f1 =false;
            while (line != "end of assignment")
            {
                string[] input = line.Split("->");
                string user = input[0];
                string teamName = input[1];
                for (int i = 0; i < teams.Count; i++)
                {
                    for (int j = 0; j < teams[i].Members.Count; j++)
                    {
                        if (teams[i].Members[j] == user || teams[i].Creator == user)
                        {
                            f1 = true;
                        }
                    }
                    if (teams[i].Creator == user)
                    {
                        f1 = true;
                    }
                }

                for (int i = 0; i < teams.Count; i++)
                {
                    if (teamName == teams[i].Name)
                    {
                        if(!f1)
                            teams[i].Members.Add(user);
                        f = true;
                    }
                }
                    if (f && f1) 
                    {
                        Console.WriteLine($"Member {user} cannot join team {teamName}!"); 
                    }
                    else if(!f && f1)
                    {
                        Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if(!f1 && !f)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                line = Console.ReadLine();
                f = false; f1 = false;
            }
            teams = teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name).ToList();
            //teams.Reverse();
            List<Team> validTeams = teams.Where(o => o.Members.Count != 0).ToList();
            List<Team> disbandedTeams = teams.Where(o => o.Members.Count == 0).ToList();

            for (int i = 0; i < validTeams.Count; i++)
            {
                Console.WriteLine(validTeams[i].Name + "\n- " + validTeams[i].Creator);
                for (int j = 0; j < validTeams[i].Members.Count; j++)
                {
                    Console.WriteLine("-- " + validTeams[i].Members[j]);
                }
            }
            Console.WriteLine("Teams to disband:");
            for (int i = 0; i < disbandedTeams.Count; i++)
            {
                Console.WriteLine(disbandedTeams[i].Name);
            }

        }
    }
}
