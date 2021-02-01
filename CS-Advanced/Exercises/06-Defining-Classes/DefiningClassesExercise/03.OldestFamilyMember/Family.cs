using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> FamilyMembers { get; set; }
        public void AddMember(Person member)
        {
            FamilyMembers.Add(member);
        }
        public Person GetOldestMember()
        {
            return FamilyMembers.OrderByDescending(o => o.Age).ToList()[0];
        }
    }
}
