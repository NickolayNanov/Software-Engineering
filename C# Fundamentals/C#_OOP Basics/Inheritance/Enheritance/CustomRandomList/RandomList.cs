using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : ArrayList
    {
        private Random rdn;

        public RandomList()
        {
            this.rdn = new Random();
        }

        public int RandomInteger()
        {
            return this.rdn.Next();
        }

        public int RandomString() => this.RandomInteger();
    }
}
