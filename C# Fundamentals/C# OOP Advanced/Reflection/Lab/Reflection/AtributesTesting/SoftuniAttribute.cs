using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SoftuniAttribute : Attribute
{
    public string Name { get; }

    public SoftuniAttribute(string name)
    {
        this.Name = name;
    }
}

