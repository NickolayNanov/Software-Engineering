using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsExercise
{
    public class Box<T>
    {

        public Box(List<T> elements)
        {
            this.Items = elements;
        }

        public List<T> Items { get; private set; }

        public int CountGreaterElements(List<double> elements, double item)
        {
            int count = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if(item.CompareTo(elements[i]) < 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}