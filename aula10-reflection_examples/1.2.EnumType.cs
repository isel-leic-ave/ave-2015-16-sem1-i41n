using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsBitflags
{
    public enum Color /* : byte */ {
        White,       // Assigned a value of 0
        Red,         // Assigned a value of 1
        Green,       // Assigned a value of 2
        Blue,        // Assigned a value of 3
        Orange,      // Assigned a value of 4
    }

    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(Enum.GetUnderlyingType(typeof(Color)));

            // Create a variable of type Color and initialize it to Blue
            Color c = Color.Blue;
            Console.WriteLine(c);               // "Blue" (General format)
            Console.WriteLine(c.ToString());    // "Blue" (General format)
            Console.WriteLine(c.ToString("G")); // "Blue" (General format)
            Console.WriteLine(c.ToString("D")); // "3"    (Decimal format)
            Console.WriteLine(c.ToString("X")); // "03"   (Hex format)

            // The following line displays "Blue".
            Console.WriteLine(Enum.Format(typeof(Color), 3, "G"));

            // Returns array of Color enums
            Color[] colors = (Color[])Enum.GetValues(typeof(Color));
            Console.WriteLine("Number of symbols defined: " + colors.Length);
            Console.WriteLine("Value\tSymbol\n-----\t------");
            foreach (Color color in colors)
            {
                // Display each symbol in Decimal and General format.
                Console.WriteLine("{0,5:D}\t{0:G}", color);
            }

            // Because Orange is defined as 4, 'c' is initialized to 4.
            c = (Color)Enum.Parse(typeof(Color), "orange", true);

            // Because Brown isn’t defined, an ArgumentException is thrown.
            try
            {
                c = (Color)Enum.Parse(typeof(Color), "Brown", false);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Brown is not defined by the Color enumerated type.");
            }

            // Creates an instance of the Color enum with a value of 1
            c = (Color)Enum.Parse(typeof(Color), "1", false);

            // Creates an instance of the Color enum with a value of 23
            c = (Color)Enum.Parse(typeof(Color), "23", false);

            // Displays "True" because Color defines Red as 1
            Console.WriteLine(Enum.IsDefined(typeof(Color), 1));

            // Displays "True" because Color defines White as 0
            Console.WriteLine(Enum.IsDefined(typeof(Color), "White"));

            // Displays "False" because a case-sensitive check is performed 
            Console.WriteLine(Enum.IsDefined(typeof(Color), "white"));

            // Displays "False" because Color doesn’t have a symbol of value 10
            Console.WriteLine(Enum.IsDefined(typeof(Color), 10));


            SetColor((Color)3);  // Blue
            try
            {
                SetColor((Color)547);  // Not a defined color
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }

        public static void SetColor(Color c)
        {
            if (!Enum.IsDefined(typeof(Color), c))
            {
                throw (new ArgumentOutOfRangeException("c", c, "You didn't pass a valid Color"));
            }
            // Set color to Red, Green, Blue, or Orange...
        }
    }
}