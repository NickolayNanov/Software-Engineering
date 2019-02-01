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

        public void Swap(string indexes)
        {
            int[] tokens = indexes.Split().Select(x => int.Parse(x)).ToArray();

            var index1 = tokens[0];
            var index2 = tokens[1];

            var temp = this.Items[index1];
            this.Items[index1] = this.Items[index2];
            this.Items[index2] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}