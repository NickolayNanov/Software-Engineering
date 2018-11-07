using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;

        public List<Person> Members
        {
            get
            {
                return this.members;
            }
            set
            {
                members = new List<Person>();
            }
        }

        public void AddMember(Person person)
        {
            this.Members.Add(person);
        }

        public Person GetOldestMemeber(List<Person> members)
        {
            Person person = new Person();

            return person = members.OrderByDescending(x => x.Age).First();
        }
    }
}
