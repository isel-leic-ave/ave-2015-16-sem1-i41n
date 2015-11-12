using System;

interface IA {void M();}
interface IB {void M();}

class X : IA, IB { 
    void IA.M() { Console.WriteLine("Implements IA"); } 
    void IB.M() { Console.WriteLine("Implements IB"); } 
}

class App {
    static void Main() {
        X x = new X();
        ((IA) x).M();
        ((IB) x).M();
        
        // x.M(); // Erro de Compilação o método M() é privado.
    }
}



