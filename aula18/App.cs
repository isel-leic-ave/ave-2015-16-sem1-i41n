using System;

class A {}

class B : A {
    public void Bar() {}
}

class App {
    static void Main() {
        A a = new B();
        
        // B b = a; // Erro de compilação 
        
        Console.WriteLine((B) a); // casting explicito => ldloc.0 + castclass
    }
    
    static void Foo1(A a) { 
        if(a is B) { // <=> instanceof do Java => gera em IL: isinst + .... + ...
            B b = (B) a;
            /*..... fazer qq coisa com o objecto do tipo B... */
            b.Bar();
        }
    }
    static void Foo2(A a) { 
        B b = a as B;
        if(b != null) { 
            /*..... fazer qq coisa com o objecto do tipo B... */
            b.Bar();
        }
    }
}



