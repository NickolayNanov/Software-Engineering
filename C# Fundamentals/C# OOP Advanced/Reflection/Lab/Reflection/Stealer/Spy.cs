using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fields)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {className}");

        var type = typeof(Hacker);

        string username = fields[0];
        string password = fields[1];

        var privateFields = type.GetFields(BindingFlags.Public |
                                            BindingFlags.NonPublic |
                                            BindingFlags.Static |
                                            BindingFlags.Instance);

        var reflectedHacker = Activator.CreateInstance(type);

        foreach (var field in privateFields.Where(f => fields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(reflectedHacker)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        var type = Type.GetType(className);

        var allFields = type.GetFields(BindingFlags.Public |
                                        BindingFlags.NonPublic |
                                        BindingFlags.Static |
                                        BindingFlags.Instance);

        foreach (var field in allFields)
        {
            if (!field.IsPrivate)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
        }

        var allAttributes = type.GetMethods(BindingFlags.NonPublic |
                                            BindingFlags.Instance);

        foreach (var atribute in allAttributes.Where(p => p.Name.StartsWith("get")))
        {
            var getter = atribute.GetBaseDefinition().IsPrivate;

            if (getter)
            {
                sb.AppendLine($"{atribute.Name} have to be public!");
            }
        }

        allAttributes = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        foreach (var atribute in allAttributes.Where(a => a.Name.StartsWith("set")))
        {
            var setter = atribute.GetBaseDefinition().IsPublic;

            if (setter)
            {
                sb.AppendLine($"{atribute.Name} have to be private!");
            }
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");

        var type = Type.GetType(className);
        var reflectedHacker = Activator.CreateInstance(type);

        var baseClass = type.BaseType;
        sb.AppendLine($"Base Class: {baseClass}");

        var privateMethods = type.GetMethods(BindingFlags.Instance |
                                             BindingFlags.NonPublic);

        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string GetAtributes(string className)
    {
        StringBuilder sb = new StringBuilder();

        var type = Type.GetType(className);

        var atributes = type.GetMethods(BindingFlags.Instance |
                                        BindingFlags.NonPublic |
                                        BindingFlags.Public);

        foreach (var method in atributes.Where(a => a.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in atributes.Where(a => a.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}

