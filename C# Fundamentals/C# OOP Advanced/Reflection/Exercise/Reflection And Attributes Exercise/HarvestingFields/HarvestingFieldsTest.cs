 namespace HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);

            string input = Console.ReadLine();

            while (input != "HARVEST")
            {
                var fields = type.GetFields(BindingFlags.Public |
                                        BindingFlags.NonPublic |
                                        BindingFlags.Instance);

                switch (input)
                {
                    case "public":
                        fields = fields.Where(f => f.IsPublic).ToArray();
                        break;
                    case "protected":
                        fields = fields.Where(f => f.IsFamily).ToArray();
                        break;
                    case "private":
                        fields = fields.Where(f => f.IsPrivate).ToArray();
                        break;
                    case "all":
                        break;
                }

                Console.WriteLine(string.Join(Environment.NewLine, fields.Select(x => $"{CheckAtribute(x).ToLower()} {x.FieldType.Name} {x.Name}")));

                input = Console.ReadLine();
            }
        }

        private static string CheckAtribute(FieldInfo x)
        {
            string attribute = x.Attributes.ToString();

            if (attribute == "Family")
            {
                attribute = "protected";
            }

            return attribute;
        }
    }
}
