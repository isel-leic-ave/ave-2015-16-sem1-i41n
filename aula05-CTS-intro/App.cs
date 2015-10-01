
class A { // => um tipo A que extende de System.Object
    int z, w;
    public void Print() {
        System.Console.WriteLine("I am A");
    }
}

struct Point { // => um tipo B que extende de System.ValueType
    int x, y;
    public void Print() {
        System.Console.WriteLine("I am Point");
    }
}

class App{
	static void Main()
	{
		System.Int32 n1; // Utilização do tipo System.Int32
        int n2; // Utilização da designação primitiva
        
        System.String s1 = "ISEL";
        string s2 = "super"; // Utilização da designação primitiva
        
        A a = new A(); // uma instância alocada em Heap => IL newobj
        Point p = new Point(); // uma instância em Stack => IL initobj
        a.Print();
        p.Print();
	}
}