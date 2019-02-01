using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Comparators
{
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person that, Person other)
        {
            int result = that.Age.CompareTo(other.Age);

            return result;
        }
    }
}
