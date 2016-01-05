using System;
using System.Windows.Forms;
using System.Collections.Generic;

class Program
{
    static void Foo(int v) { Console.WriteLine("ConsoleHandler = " + v); }

    static void Main()
    {
        Counter c = new Counter();
        c.DoIt(5, 7);        
        Observer h1 = Program.Foo;
        Observer h2 = value => MessageBox.Show("Item = " + value);
        Observer h3 = new A(2).FeedbackBeep;
        c.obs += h1; c.obs += h2; c.obs += h3;
        GC.Collect();
        h1.GetHashCode();
        c.DoIt(5, 7);
    }
}

public delegate void Observer(int value);

class Counter
{
    /* Gera:
     *   * um par de métodos: add_obs e remove_obs
     *   * um campo privado obs do tipo Observer
     *   * um membro evento obs do tipo Observer
     * 
     * A acessibilidade estabelece a acessibilidade dos métodos add_obs e remove_obs
     */
    public event Observer obs;
    
    public void NotifyObservers(int n) {
        if(obs != null) obs(n); // <=> obs.Invoke(n);
    }

    // Notifica o método de callback Feedback do objecto o,
    // por cada iteração de from a to.
    public void DoIt(int from, int to)
    {
        for (int i = from; i <= to; i++)
        {
            NotifyObservers(i);
        }
    }
}


class A {

    int occurences;

    public A(int n){this.occurences = n;}

    public void FeedbackBeep(int value)
    {
        for (int i = 0; i < occurences; i++)
        {
            Console.Beep();
            Console.Write(" Hello : " + value);
        }
        Console.WriteLine();
    }

}

