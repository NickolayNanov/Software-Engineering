namespace HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (input != "HARVEST")
            {
                Type type = typeof(HarvestingFields);
                BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
                FieldInfo[] fields = type.GetFields(flags);

                switch (input)
                {
                    case "public":
                        fields = fields.Where(f => f.IsPublic).ToArray();
                        break;
                    case "private":
                        fields = fields.Where(f => f.IsPrivate).ToArray();
                        break;
                    case "protected":
                        fields = fields.Where(f => f.IsFamily).ToArray();
                        break;
                    case "all":
                        break;
                }

                Console.WriteLine(string.Join(Environment.NewLine, fields.Select(x => $"{GetAccessModifier(x).ToLower()} {x.FieldType.Name} {x.Name}")));

                input = Console.ReadLine();
            }
        }

        private static string GetAccessModifier(FieldInfo x)
        {
            string result = x.Attributes.ToString();

            if (x.IsFamily)
            {
                result = "protected";
            }

            return result;
        }
    }
}
