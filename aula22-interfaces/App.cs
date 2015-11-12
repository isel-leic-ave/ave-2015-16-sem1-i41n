using System;

interface I {void M();}

class A : I{ public void M() { Console.WriteLine("A"); } }

class B: A, I { public new virtual void M() { Console.WriteLine("B"); } }

class C: B { public override void M() { Console.WriteLine("C"); } }

class D: C, I { public new void M() { Console.WriteLine("D"); } }


class App {
    static void Main() {
        D d = new D();
        I i = d;
        A a = d;
        B b = d;
        C c = d;
        i.M(); a.M(); b.M(); c.M(); d.M();
    }
}



