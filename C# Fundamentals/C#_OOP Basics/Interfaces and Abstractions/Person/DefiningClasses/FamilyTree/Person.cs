using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTree
{
    public class Person
    {
        private string name;
        private string birthday;
        private HashSet<Person> children;
        private HashSet<Person> parents;

        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.children = new HashSet<Person>();
            this.parents = new HashSet<Person>();
        }
        
        public HashSet<Person> Parents
        {
            get { return parents; }
            set { parents = value; }
        }      

        public HashSet<Person> Children
        {
            get { return children; }
            set { children = value; }
        }
   
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }        
    }
}
