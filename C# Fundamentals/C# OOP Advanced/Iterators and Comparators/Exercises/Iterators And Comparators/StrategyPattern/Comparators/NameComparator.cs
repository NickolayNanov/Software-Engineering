using System.Collections.Generic;

namespace StrategyPattern.Comparators
{
    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person that, Person other)
        {
            int result = that.Name.Length.CompareTo(other.Name.Length);

            if(result == 0)
            {
                result = that.Name.ToLower()[0].CompareTo(other.Name.ToLower()[0]);
            }

            return result;  
        }
    }
}
