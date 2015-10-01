using System;

struct Point { // => um tipo B que extende de System.ValueType
    int x, y;
    
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    public override string ToString() {
        return string.Format("x = {0}, y = {1}", x, y);
    }
}

class App{
	static void Main()
	{
        // Point p = new Point(); // uma instância em Stack => IL initobj
        
        Point p = new Point(7,9); // uma instância em Stack => call Point::.ctor(int32, int32)
      
        Console.WriteLine(p.ToString());
        
        object o = p; // box
        
        Console.WriteLine(o.ToString());
        Console.WriteLine(o.GetHashCode());
        
        // o.y = 11;
        
        Console.WriteLine(o.ToString());
        Console.WriteLine(o.GetHashCode());
        
	}
}