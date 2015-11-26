using System;

class Program{
    static void Main(){
        CounterWrapper c = new CounterWrapper(new Counter());
        c.CountEvent += n => Console.WriteLine("Alerta " + n); // call add_CountEvent
        c.DoIt(5, 7);
    }
}

public class CounterWrapper {

    private Counter c;
    public event CountEventHandler CountEvent; // gera um campo CountEvent + add_CountEvent()
    
    public CounterWrapper(Counter c) { 
        this.c = c; 
        c.AddObserver(new SubscriberWrapper(this));
    }
    public void DoIt(int start, int end) { c.DoIt(start, end); }
    
    public void CallCountEvent(int n){
        CountEventHandler tmp = CountEvent;
        if(tmp != null)
            tmp(n); // <=> tmp.Invoke(n);
    }
}

public delegate void CountEventHandler(int n);

public class SubscriberWrapper : Observer {
    private CounterWrapper c;
    public SubscriberWrapper(CounterWrapper c) {this.c = c;}
    public void Feedback(int n){
        c.CallCountEvent(n);
    }
}
