using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        public IList<T> Items;

        public Box()
        {
            this.Items = new List<T>();
        }

        public int Count => this.Items.Count;

        public void Add(T element)
        {
            this.Items.Add(element);
        }   

        public T Remove()
        {
            var element = this.Items[this.Items.Count - 1];
            this.Items.RemoveAt(this.Items.Count - 1);

            return element;
        }
    }
}