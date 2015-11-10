using System;

class A {}

struct B {}

struct C {
    public override string ToString() {
        return "I am a C";
    }
}

class App {
    static void Main() {
        A a = new A();
        B b = new B();
        C c = new C();
        
        a.GetType();
        b.GetType();
        
        a.ToString();
        b.ToString();
        c.ToString();
    }
}



