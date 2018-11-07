using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    class Pesho : Person
    {
        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public override string ToString()
        {
            return $"{this.Nickname} is {this.Age} years old.";
        }
    }
}
