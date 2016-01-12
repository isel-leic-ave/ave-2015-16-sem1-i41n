using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

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
    ~A() {
        Console.WriteLine("Cleaning A....");
    }
}

class Program
{
    static void Foo(int v) {  Console.WriteLine("ConsoleHandler = " + v);  }

    static void Main() {
        Counter c = new Counter();
        c.DoIt(5, 7);        
        // Observer h1 = Program.Foo;
        
        Observer h2 = value => MessageBox.Show("Item = " + value);
        A a = new A(2);
        
        // c.obs += h1; c.obs += h2; 
        
        c.obs += a.FeedbackBeep;
        
        c.DoIt(5, 7);
        
        GC.Collect(); // Não existe referência para o objecto a
        Console.WriteLine("GC collecting...");
        Console.ReadLine();
        
        c.DoIt(5, 7);
        c.DoIt(5, 7);
        c.DoIt(5, 7);
        // a.GetHashCode();
    }
}

public delegate void Observer(int value);

class WrapperObserver{
    public readonly WeakReference<Object> target;
    public readonly MethodInfo mi;
    public WrapperObserver(Observer o) {
        this.target =  new WeakReference<Object>(o.Target);
        this.mi = o.Method;
    }
    // Implementar Equals e GetHashCode
}

class Counter {
    List<WrapperObserver> handlers = new List<WrapperObserver>();

    public event Observer obs {
        add { handlers.Add(new WrapperObserver(value)); }
        remove { handlers.Remove(new WrapperObserver(value)); }
    }
    public void NotifyObservers(int n) {
        foreach(WrapperObserver wo in handlers) {
            Object target;
            if(wo.target.TryGetTarget(out target))
                wo.mi.Invoke(target, new object[]{n});
            else { 
                // handlers.Remove(wo); //  !!!! Excepção de Concorrent modification
            }
        }
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