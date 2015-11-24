using System;
using System.Windows.Forms;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Counter c = new Counter();
        c.AddObserver(new FeedbackToConsole());
        c.AddObserver(new FeedbackToConsole());
        c.AddObserver(new FeedbackToMbox());
        // c.AddObserver(new FeedbackBeep());
        c.DoIt(5, 7);
    }
}

/* 
 * O Counter representa o papel de um Publisher - Lança notificações/eventos.
 */
public class Counter
{
    private List<Observer> obs = new List<Observer>();

    public void AddObserver(Observer o) { obs.Add(o); }
    public void RemoveObserver(Observer o) { obs.Remove(o); }

    public void NotifyObservers(int n) { foreach (Observer o in obs) o.Feedback(n); }

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

/*
 * Definição do contracto Observer.
 */
public interface Observer
{
    void Feedback(int value);
}

class FeedbackToConsole : Observer
{
    public void Feedback(int value)
    {
        Console.WriteLine("ConsoleHandler = " + value); 
    }
}

class FeedbackToMbox : Observer
{
    public void Feedback(int value)
    {
        MessageBox.Show("Item = " + value);
    }
}

class FeedbackBeep : Observer
{
    public void Feedback(int value)
    {
        for (int i = 0; i < value; i++)
        {
            Console.Beep();
            Console.Write("Hello ");
        }
        Console.WriteLine();
    }
}
