using System;
using System.Diagnostics;
using System.Reflection;


[Serializable]
[DebuggerDisplayAttribute("Simao", Name = "Jose", Target = typeof(Program))]
public sealed class Program
{
    [Conditional("Debug")]
    [Conditional("Release")]
    public void DoSomething() { }

    public Program()
    {
    }

    public static void Main()
    {
        // Show the set of attributes applied to this type
        ShowAttributes(typeof(Program));

        // Get the set of methods associated with the type
        MemberInfo[] members = typeof(Program).FindMembers(
           MemberTypes.Constructor | MemberTypes.Method,
           BindingFlags.DeclaredOnly | BindingFlags.Instance |
           BindingFlags.Public | BindingFlags.Static,
           Type.FilterName, "*");

        foreach (MemberInfo member in members)
        {
            // Show the set of attributes applied to this member
            ShowAttributes(member);
        }
    }

    private static void ShowAttributes(MemberInfo attributeTarget)
    {
        Attribute[] attributes = Attribute.GetCustomAttributes(attributeTarget);

        Console.WriteLine("Attributes applied to {0}: {1}",
           attributeTarget.Name, (attributes.Length == 0 ? "None" : String.Empty));

        foreach (Attribute attribute in attributes)
        {
            // Display the type of each applied attribute
            Console.WriteLine("  {0}", attribute.GetType().ToString());

            if (attribute is DefaultMemberAttribute)
                Console.WriteLine("    MemberName={0}",
                   ((DefaultMemberAttribute)attribute).MemberName);

            if (attribute is ConditionalAttribute)
                Console.WriteLine("    ConditionString={0}",
                   ((ConditionalAttribute)attribute).ConditionString);

            if (attribute is CLSCompliantAttribute)
                Console.WriteLine("    IsCompliant={0}",
                   ((CLSCompliantAttribute)attribute).IsCompliant);

            DebuggerDisplayAttribute dda = attribute as DebuggerDisplayAttribute;
            if (dda != null)
            {
                Console.WriteLine("    Value={0}, Name={1}, Target={2}",
                   dda.Value, dda.Name, dda.Target);
            }
        }
        Console.WriteLine();
    }
}
