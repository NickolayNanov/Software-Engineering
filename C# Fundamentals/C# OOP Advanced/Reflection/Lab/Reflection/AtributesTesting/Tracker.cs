using System;
using System.Reflection;

public class Tracker
{
    public void PrintMethodByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Public |
                                        BindingFlags.Instance |
                                        BindingFlags.Static);

        
        foreach (var method in methods)
        {
            var customAttribute = method.GetCustomAttribute<SoftuniAttribute>();

            if (customAttribute != null)
            {
                System.Console.WriteLine($"{method.Name} is written by {customAttribute.Name}");
            }
        }
    }
}

