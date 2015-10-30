using System;

public enum Color { Red }


namespace DefiningCustomAttribute
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple=true)]
    public sealed class TesterAttribute : Attribute
    {
        public TesterAttribute(String Name)
        {
            this.Name = Name;
            this.DateOfTest = DateOfTest;
        }

        public string Name { get; set; }
        public string DateOfTest { get; set; }
    }

    [Tester("user2")]
    [Tester("user1", DateOfTest="1-1-1990")]
    public sealed class SomeType
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(SomeType);
            Console.WriteLine(t.IsDefined(typeof(TesterAttribute), false));
            TesterAttribute[] ta = 
                (TesterAttribute[]) t.GetCustomAttributes(typeof(TesterAttribute), false);
            foreach (TesterAttribute a in ta) {
                Console.WriteLine(a.Name);
            }
        }
    }
}









