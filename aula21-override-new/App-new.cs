using System;

class A{
    public new string ToString() {
        return "I am an A";
    }
}

class B : A {
    string Object.ToString() {
        return "I am an B";
    }
}

class App {
    static void Main() {
        B b = new B();
        A a = b;
        object o = a;
        
        a.ToString();
        o.ToString();
    }
}



