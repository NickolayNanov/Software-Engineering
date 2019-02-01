using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    public class Farm<T> : IEnumerable<T>
    {
        private string owner;
        private List<T> animals;

        public Farm()
        {
            this.animals = new List<T>();
        }
        
        public List<T> Animals { get => animals; set => animals = value; }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.animals.Count; i++)
            {
                yield return this.animals[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
