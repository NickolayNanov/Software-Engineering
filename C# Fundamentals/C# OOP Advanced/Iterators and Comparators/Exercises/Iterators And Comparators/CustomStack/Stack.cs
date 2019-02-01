using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] elements;

        public Stack()
        {
            this.elements = new T[0];
        }

        public Stack(T[] elements)
        {
            Array.Reverse(elements);
            this.elements = elements;
        }

        public T Pop()
        {
            if(this.elements.Length == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            var element = this.elements[0];
            this.elements[0] = default(T);

            DecreaseStack();
            
            return element;
        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                EnlargeStack();
                this.elements[0] = element;
            }           
        }

        private void EnlargeStack()
        {
            T[] temp = new T[this.elements.Length + 1];
            int count = 0;

            for (int i = this.elements.Length - 1; i >= 0; i--)
            {                
                temp[temp.Length - 1 - count++] = this.elements[i];
            }

            this.elements = temp;
        }

        private void DecreaseStack()
        {
            T[] temp = new T[this.elements.Length - 1];

            for (int i = this.elements.Length - 1; i >= 1; i--)
            {
                temp[i - 1] = this.elements[i];
            }

            this.elements = temp;
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
