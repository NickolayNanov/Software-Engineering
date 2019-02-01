namespace Reflection
{
    using System;
    using System.Reflection;
    using System.Text;

    class StartUp
    {
        static void Main(string[] args)
        {
            //Farm<Animal> animals = new Farm<Animal>();

            //var cat = (Cat)Activator.CreateInstance(typeof(Cat), "Pesho", 13);
            //var dog = (Dog)Activator.CreateInstance(typeof(Dog), "Stoyan", 3);

            //var typeOfCat = cat.GetType();
            //var typeOfDog = dog.GetType();

            //PrintObjectProperties(cat, typeOfCat);
            //PrintObjectProperties(dog, typeOfDog);

            //StealAnotherClassInfo();

            Spy spy = new Spy();

            Console.WriteLine(spy.StealAnotherClassInfo());
        }

        public string StealAnotherClassInfo()
        {
            StringBuilder sb = new StringBuilder();

            var fields = typeof(Animal).GetFields(BindingFlags.NonPublic);

            Console.WriteLine($"Working On {typeof(Animal).Name}");
            foreach (var field in fields)
            {
                string line = $"{field.Name} ==> {field.GetValue(field)}";
                sb.AppendLine(line);
            }

            return sb.ToString().TrimEnd();
        }

        private static void PrintObjectProperties(Animal animal, Type typeOfCat)
        {
            var propertiesCat = typeOfCat.GetProperties();

            Console.WriteLine(animal.GetType().Name + " is a " + animal.GetType().BaseType.Name);

            foreach (var prop in propertiesCat)
            {
                Console.WriteLine(prop.GetValue(animal));
            }
            Console.WriteLine();
        }
    }
}
