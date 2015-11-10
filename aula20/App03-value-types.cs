using System;

struct Point {
    int x, y;
    
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }    
}

class A {}

class App {
    static void Main() {
        A a = new A();
        Point p = new Point(7, 11);
        
        Type typeOfA = a.GetType();
        Type typeOfPoint = p.GetType();
    }
}



