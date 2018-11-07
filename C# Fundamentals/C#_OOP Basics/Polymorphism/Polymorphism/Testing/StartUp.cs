using System;

namespace Testing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IAnimal animal = new Person() {Kind = "animal" };
            Mamal mamal = new Person();
            Person person = new Person();
            Cat cat = new Cat();

            Walk(person);
            Walk(cat);
        }

        public static void Walk(IAnimal animal)
        {
            animal.Walk();            
        }
    }
}
