using System;
using System.Windows.Forms;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Counter c = new Counter();
        c.DoIt(5, 7);
        c.AddObserver(value => Console.WriteLine("ConsoleHandler = " + value));
        c.AddObserver(value => MessageBox.Show("Item = " + value));
        c.AddObserver(new A(2).FeedbackBeep);
        c.DoIt(5, 7);
    }
}


public delegate void Observer(int value);


class Counter
{
    private Observer obs;

    public void AddObserver(Observer o)
    {
        // obs = (Observer) Delegate.Combine(obs, o);
        obs += o;
    }

    public void RemoveObserver(Observer o)
    {
        // obs = (Observer) Delegate.Remove(obs, o);
        obs -= o;
    }

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

