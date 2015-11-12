using System;

class A{
    public override string ToString() {
        return "I am an A";
    }
}

class App {
    static void Main() {
        A a = new A();
        object o = a;
        
        a.ToString();
        o.ToString();
    }
}



