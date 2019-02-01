namespace DataBaseExtended
{
    using Contracts;
    using System;
    using System.Linq;

    public class DatabaseExtended
    {
        private const int Capacity = 16;
        private IPerson[] data;
        private int currentIndex;

        public DatabaseExtended()
        {
            this.data = new IPerson[Capacity];
            this.currentIndex = -1;
        }

        public DatabaseExtended(IPerson[] people)
            : this()
        {
            this.data = new IPerson[Capacity];

            if (people.Length > Capacity)
            {
                throw new InvalidOperationException("You entered too large input!");
            }

            for (int i = 0; i < people.Length; i++)
            {
                this.data[i] = people[i];
            }

            this.currentIndex = people.Length - 1;
        }

        public void Add(IPerson person)
        {
            if (this.currentIndex == Capacity - 1)
            {
                throw new InvalidOperationException("Database is full!");
            }

            if (this.data.Count(p => p != null) > 0)
            {
                foreach (IPerson per in this.data)
                {
                    if (per.Name == person.Name || per.Id == person.Id)
                    {
                        throw new InvalidOperationException("There is already a person with that Id/Name!");
                    }
                }
            }

            this.data[++currentIndex] = person;
        }



        public void Remove()
        {
            if (this.currentIndex == -1)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.data[currentIndex] = null;
            currentIndex--;
        }

        public IPerson FindByUsername(string name)
        {
            if (this.data.Count(p => p != null) > 0)
            {
                IPerson person = this.data.Where(p => p != null).FirstOrDefault(p => p.Name == name);

                if (person == null)
                {
                    throw new InvalidOperationException("There is no person with this name!");
                }

                if (name == null)
                {
                    throw new ArgumentException("Name cannot be null!");
                }

                return person;
            }
            else
            {
                throw new InvalidOperationException("The collection is empty!");
            }
        }

        public IPerson FindById(long id)
        {
            if (this.data.Count(p => p != null) > 0)
            {
                IPerson person = this.data.Where(p => p != null).FirstOrDefault(p => p.Id == id);

                if (person == null)
                {
                    throw new InvalidOperationException("There is no person with this id!");
                }

                if (id < 0)
                {
                    throw new ArgumentException("Username's id cannot be negative!");
                }

                return person;
            }
            else
            {
                throw new InvalidOperationException("The collection is empty!");
            }
        }
    }
}
