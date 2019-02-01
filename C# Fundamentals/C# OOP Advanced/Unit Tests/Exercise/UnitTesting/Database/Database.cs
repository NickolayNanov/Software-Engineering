namespace DataBase
{
    using System;
    using System.Linq;

    public class DataBase
    {
        private const int Capacity = 16;
        private int[] data;
        private int currentIndex;

        public DataBase()
        {
            this.data = new int[Capacity];
            this.currentIndex = -1;
        }

        public DataBase(int[] values)
            : this()
        {
            this.data = new int[Capacity];

            if (values.Length > Capacity)
            {
                throw new InvalidOperationException("You entered too large input!");
            }

            for (int i = 0; i < values.Length; i++)
            {
                this.data[i] = values[i];
            }

            this.currentIndex = values.Length - 1;
        }

        public void Add(int element)
        {
            if (this.currentIndex == Capacity - 1)
            {
                throw new InvalidOperationException("Database is full!");
            }

            this.data[++currentIndex] = element;
        }

        public void Remove()
        {
            if (this.currentIndex == -1)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.data[currentIndex] = 0;
            currentIndex--;
        }

        public int[] Fetch()
        {
            return this.data.Take(this.currentIndex + 1).ToArray();
        }
    }
}
