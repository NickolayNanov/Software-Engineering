using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomList
{
    public class CustomCollection<T> : ICustomList<T>  where T : IComparable<T>  
    {
        private const int initialCapacity = 4;
        private T[] array;

        public int Count { get; private set; }

        public CustomCollection()
        {
            this.array = new T[initialCapacity];
            this.Count = 0;
        }

        public void Add(T element)
        {
            if(this.array.Length == this.Count)
            {
                Resize();
            }

            this.array[this.Count++] = element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if(this.array[i].CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public int CountGreaterThan(T element)
        {            
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            int count = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if(array[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T max = this.array[0];

            for (int i = 0; i < this.Count; i++)
            {
                if(array[i].CompareTo(max) > 0)
                {
                    max = this.array[i];
                }
            }

            return max;
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T min = this.array[0];

            for (int i = 0; i < this.Count; i++)
            {
                if (array[i].CompareTo(min) < 0)
                {
                    min = array[i];
                }
            }

            return min;
        }

        public T Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            if(index < 0 || index >= this.Count)
            {
                throw new InvalidOperationException();
            }

            T element = this.array[index];
            this.array[index] = default(T);
            this.Count--;

            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            if(this.array.Length != this.Count)
            {
                this.array[this.Count] = default(T);
            }

            return element;
        }

        public void Swap(int index1, int index2)
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            if (index1 < 0 || index1 >= this.Count || index2 < 0 || index2 >= this.Count)
            {
                throw new InvalidOperationException();
            }

            T temp = this.array[index2];
            this.array[index2] = this.array[index1];
            this.array[index1] = temp;
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

        public override string ToString()
        {
            return string.Join("\n", this.array.Take(this.Count));
        }
    }
}
