using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reflection
{
    public class Spy
    {
        public string StealAnotherClassInfo()
        {
            StringBuilder sb = new StringBuilder();

            var type = typeof(Animal);

            var animal = Activator.CreateInstance(typeof(Animal));

            var privateFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var privateMethod = type.GetMethod("PrivateEat", BindingFlags.NonPublic | BindingFlags.Instance);
            var publicMethod = type.GetMethod("Eat");
            var constructor = type.GetConstructor(new Type[] { });

            publicMethod.Invoke(animal, new object[] { });

            return sb.ToString().TrimEnd();
        }
    }
}
