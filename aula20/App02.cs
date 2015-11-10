using System;

class Point {
    int x, y;
    
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    
    public string M() { 
        return String.Format(
            "{0}, {1}", 
            x, 
            y);
    }
    public string Foo() { 
        return "Foo";
    }
}

class App {
    static void Main() {
        Point p = null;
        p.Foo();
    }
}



