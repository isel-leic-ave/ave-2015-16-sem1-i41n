using System;

interface I    { void m(); }
class A : I    { public virtual void m()  { Console.WriteLine("A"); } }
class B : A    { public virtual void m()  { Console.WriteLine("B"); } }
class C : B    { public override void m() { Console.WriteLine("C"); } }

class App {
    static void Main() {
        C c = new C(); 
        A a = c; 
        B b = c; 
        I i = c; 
        a.m(); b.m(); c.m(); i.m();
    }

}