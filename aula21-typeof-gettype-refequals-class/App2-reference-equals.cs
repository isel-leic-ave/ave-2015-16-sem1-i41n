using System;

class App {
    static void Main() {
        string seed = "ISEL";
        string line = "";
        // while(!line.Equals(seed)) {
        // while(line != seed) { // NÃO compara identidade. Compara o estado dos objectos = EQUALS
        while(!Object.ReferenceEquals(line,seed))  {
            Console.Write("input: ");
            line = Console.ReadLine();
        }
        Console.Write("Get it!!!");
    }
}



