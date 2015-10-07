using System;

interface Setter {
    void SetX(int x);
    void SetY(int y);
}

struct Point : Setter { // => um tipo B que extende de System.ValueType
    public int x, y;
    
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    public override string ToString() {
        return string.Format("x = {0}, y = {1}", x, y);
    }
    
    
    public double GetModule() {return Math.Sqrt(x*x + y*y)}
    public void SetX(int x) {this.x = x;}
    public void SetY(int y) {this.y = y;}
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
        
        // ((Point) o).y = 11; // Não se pode modificar uma versão temporária unbox
        // <=>
        
        // ((Point) o).SetY(11);// O objecto o NÃO foi modificado
        
        Setter i = (Setter) o;
        i.SetY(11);
        
        /*
        Point p2 = (Point) o; // unbox
        p2.y = 11; // modificar o objecto em Stack
        o = p2; // o passa a referenciar um novo objecto resultante do boxing
        */
        
        Console.WriteLine(o.ToString());
        Console.WriteLine(o.GetHashCode());
        
	}
} 