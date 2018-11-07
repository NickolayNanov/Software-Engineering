using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings
    {
        private List<string> data = new List<string>();

        public void Push(string item)
        {
            this.data.Add(item);
        }

        public string Pop()
        {
            string item = this.data[data.Count - 1];
            this.data.Remove(item);
            return item;
        }

        public string Peek()
        {
            return this.data[data.Count - 1];
        }

        public bool isEmpty()
        {
            return this.data.Count == 0;
        }
    }
}
