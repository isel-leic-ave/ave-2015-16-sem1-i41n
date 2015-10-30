//#define TEST
#define VERIFY

using System;
using System.Diagnostics;
using System.Reflection;


[Conditional("TEST")]
[Conditional("VERIFY")]
public sealed class CondAttribute : Attribute
{
}

[Cond]
public static class Program
{
    public static void Main()
    {
        Console.WriteLine("CondAttribute is {0}applied to Program type.",
           Attribute.IsDefined(typeof(Program),
              typeof(CondAttribute)) ? "" : "not ");
    }
}

