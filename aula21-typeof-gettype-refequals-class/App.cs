using System;

class A{}
class B: A {}

class App {
    static void Main() {
        A a = new A();
        B b = new B();
        
        Console.WriteLine("a is compatible with A = " + (a is A));
        Console.WriteLine("a is instance of class A = " + (Object.ReferenceEquals(a.GetType(), typeof(A))));
        Console.WriteLine("b is compatible with A = " + (b is A));
        Console.WriteLine("a is instance of class A = " + (Object.ReferenceEquals(b.GetType(), typeof(A))));
    }
}



