using System;
using System.Windows.Forms;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Counter c = new Counter();
        c.AddObserver(value => Console.WriteLine("ConsoleHandler = " + value));
        c.AddObserver(value => MessageBox.Show("Item = " + value) );
        c.DoIt(5, 7);
    }
}

/* 
 * O Counter representa o papel de um Publisher - Lan�a notifica��es/eventos.
 */
class Counter
{
    private List<Observer> obs = new List<Observer>();

    public void AddObserver(Observer o) { obs.Add(o); }
    public void RemoveObserver(Observer o) { obs.Remove(o); }

    public void NotifyObservers(int n) { foreach (Observer o in obs) o.Invoke(n); }

    // Notifica o m�todo de callback Feedback do objecto o,
    // por cada itera��o de from a to.
    public void DoIt(int from, int to)
    {
        for (int i = from; i <= to; i++)
        {
            NotifyObservers(i);
        }
    }
}

/*
 * Defini��o do contracto Observer.
 */
delegate void Observer(int value);

