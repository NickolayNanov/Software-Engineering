namespace DataBaseExtended.Models
{
    using Contracts;

    public class Person : IPerson
    {
        private long id;
        private string name;

        public Person(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public long Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }
    }
}
