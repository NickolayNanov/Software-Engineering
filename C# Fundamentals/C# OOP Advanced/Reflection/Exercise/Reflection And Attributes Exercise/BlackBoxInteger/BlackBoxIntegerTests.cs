namespace BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class BlackBoxIntegerTests
    {
        private StringBuilder sb;

        public BlackBoxIntegerTests()
        {
            this.sb = new StringBuilder();
        }

        public string Run()
        {
            var type = typeof(BlackBoxInteger);
            var reflectedObject = Activator.CreateInstance(type, true);

            var methods = type.GetMethods(BindingFlags.Public |
                                          BindingFlags.NonPublic |
                                          BindingFlags.Static |
                                          BindingFlags.Instance);

            var fields = type.GetFields(BindingFlags.NonPublic |
                                        BindingFlags.Instance |
                                        BindingFlags.Public);

            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split('_');

                var command = tokens[0];
                var value = int.Parse(tokens[1]);

                methods.FirstOrDefault(m => m.Name == command)?.Invoke(reflectedObject, new object[] { value });

                foreach (var field in fields)
                {
                    this.sb.AppendLine(field.GetValue(reflectedObject).ToString());
                }

                input = Console.ReadLine();
            }

            return this.sb.ToString().Trim();
        }
    }
}