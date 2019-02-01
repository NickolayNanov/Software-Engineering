
namespace BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;


    public class BlackBoxIntegerTests
    {
        private StringBuilder sb;
        private BindingFlags flagsForFields = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        private BindingFlags flagsForMethods = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        public BlackBoxIntegerTests()
        {
            this.sb = new StringBuilder();
        }

        public string Run()
        {
            Type type = typeof(BlackBoxInteger);

            FieldInfo[] fields = type.GetFields(flagsForFields);
            MethodInfo[] methods = type.GetMethods(flagsForMethods);
            BlackBoxInteger instance = (BlackBoxInteger)Activator.CreateInstance(type, true);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split('_');
                string command = tokens[0];
                int value = int.Parse(tokens[1]);

                methods.FirstOrDefault(method => method.Name == command)?.Invoke(instance, new object[] { value });

                foreach (var field in fields)
                {
                    this.sb.AppendLine(field.GetValue(instance).ToString());
                }
                
                input = Console.ReadLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
