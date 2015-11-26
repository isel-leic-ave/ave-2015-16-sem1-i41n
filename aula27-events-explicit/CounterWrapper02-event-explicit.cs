using System;

class Program{
    static void Main(){
        CounterWrapper c = new CounterWrapper(new Counter());
        CountEventHandler a = n => Console.WriteLine("Alerta " + n);
        c.CountEvent += a; // call add_CountEvent
        c.DoIt(5, 7);
        c.CountEvent -= a; // call remove_CountEvent
        c.DoIt(5, 7);
    }
}

public class CounterWrapper {

    private Counter c;
    public event CountEventHandler CountEvent { // gera add_CountEvent() e o remove_CountEvent()
        add{ c.AddObserver(new SubscriberWrapper(value)); }
        remove{ c.RemoveObserver(new SubscriberWrapper(value)); }
    }
    public CounterWrapper(Counter c) { 
        this.c = c; 
    }
    public void DoIt(int start, int end) { c.DoIt(start, end); }
}

public delegate void CountEventHandler(int n);

public class SubscriberWrapper : Observer {
    private CountEventHandler handler;
    public SubscriberWrapper(CountEventHandler h) {this.handler = h;}
    public void Feedback(int n){
        handler(n);
    }
    public override bool Equals(Object o) {
        SubscriberWrapper other = o as SubscriberWrapper;
        if(other == null) return false;
        return this.handler.Equals(other.handler);
    }
    public override int GetHashCode() {
        return this.handler.GetHashCode();
    }
}
