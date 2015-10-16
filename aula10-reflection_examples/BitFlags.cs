using System;
using System.IO;

namespace BitFlags
{
    [Flags] 	// The C# compiler allows either "Flags" or "FlagsAttribute".
    public enum Actions
    {
        Read = 0x0001,
        Write = 0x0002,
        Delete = 0x0004,
        Query = 0x0008,
        Sync = 0x0010
    }

    public static class Program
    {
        public static void Main()
        {
            String file = @"C:\RECOVERY.DAT";
            FileAttributes attributes = File.GetAttributes(file);
            Console.WriteLine("Is {0} hidden? {1}", file,
               (attributes & FileAttributes.Hidden) != 0);

            Actions actions = Actions.Read | Actions.Write; // 0x0003
            Console.WriteLine(actions.ToString());          // "Read, Write" 

            // Because Query is defined as 8, 'a' is initialized to 8.
            Actions a = (Actions)Enum.Parse(typeof(Actions), "Query", true);

            // Because Query and Read are defined, 'a' is initialized to 9.
            a = (Actions)Enum.Parse(typeof(Actions), "Query, Read", false);

            // Creates an instance of the Actions enum with a value of 28
            a = (Actions)Enum.Parse(typeof(Actions), "28", false);
            Console.WriteLine(a.ToString());  // "Delete, Query, Sync"

            a = (Actions)Enum.Parse(typeof(Actions), "Delete, Sync");
            Console.WriteLine(a.ToString());
        }
    }
}