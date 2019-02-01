using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box
    {
        public IList<T> Items = new List<T>();

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

        public int Count => this.Items.Count;
    }
}
