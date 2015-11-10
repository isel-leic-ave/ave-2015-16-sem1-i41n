using System;

class A {
    public virtual string M() { return "I am A";}
}

class B : A {
    public override string M() { return base.M() + " and B"; }
}

class App {
    static void Main() {
        Console.WriteLine((new B()).M());
    }
}



