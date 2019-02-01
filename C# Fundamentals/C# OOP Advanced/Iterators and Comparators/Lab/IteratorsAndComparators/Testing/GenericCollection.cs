using System;
using System.Collections;
using System.Collections.Generic;

namespace Testing
{
    public class GenericCollection<T> : IEnumerable<T>
    {
        private T[] array;

        public GenericCollection()
        {
            this.array = new T[4];
            this.Count = 0;
        }

        public int Count { get; private set; }
        public int Capacity => this.array.Length;

        public void Add(T element)
        {
            if(this.Count == this.array.Length)
            {
                Resize();
            }

            this.array[this.Count++] = element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Collection(this.array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            T[] tempArray = new T[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                tempArray[i] = this.array[i];
            }

            this.array = tempArray;
        }

        private class Collection : IEnumerator<T>
        {
            private readonly T[] array;
            private int currentIndex;

            public Collection(T[] array)
            {
                this.Reset();
                this.array = array;
            }

            public T Current => this.array[currentIndex];

            object IEnumerator.Current => this.array[currentIndex];

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++currentIndex < this.array.Length;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
