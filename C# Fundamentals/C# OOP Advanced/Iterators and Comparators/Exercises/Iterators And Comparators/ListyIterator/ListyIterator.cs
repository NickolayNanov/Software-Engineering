namespace ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private T[] elements;
        private int currentIndex;

        public ListyIterator(T[] input)
        {
            this.elements = input;
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (currentIndex + 1 < this.elements.Length)
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }
        
        public bool HasNext()
        {
            return currentIndex + 1 < this.elements.Length;
        }

        public void Print()
        {
            if(this.elements.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[currentIndex]);
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", this.elements));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
