using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    class A
    {
        public int a;
        public String b;
    }

    class B
    {
        public int a { get; set; }
        public String b { get; set; }
    }

    class Program
    {
        static Object Mapper(Object src, Type typeDst)
        {
            // creates a new object of the type represented by typeDst
            Object dst = Activator.CreateInstance(typeDst);

            Type typeScr = src.GetType();

            // get the descriptor of all public fields
            FieldInfo[] fields = typeScr.GetFields();

            for (int i = 0; i < fields.Length; ++i)
            {
                PropertyInfo pi = typeDst.GetProperty(fields[i].Name);
                if (pi != null && pi.PropertyType == fields[i].FieldType)
                {
                    Object value = fields[i].GetValue(src);
                    pi.SetValue(dst, value); // dst.'P' = value
                }
            }

            return dst;
        }

        static void Main(string[] args)
        {
            A a = new A();
            a.a = 10;
            a.b = "AVE";

            B other = (B)Mapper(a, typeof(B));

            Console.WriteLine("a.a={0} other.a={1}", a.a, other.a);
            Console.WriteLine("a.b={0} other.b={1}", a.b, other.b);
        }

    }
}