using System;

class Program{
    static void Main(){
        CounterWrapper c = new CounterWrapper(new Counter());
        c.CountEvent += n => Console.WriteLine("Alerta " + n);
        c.DoIt(5, 7);
    }
}

public class CounterWrapper {

    private Counter c;
    private SubscriberWrapper sub;
    public event CountEventHandler CountEvent; // gera um campo CountEvent + add_CountEvent()
    
    public CounterWrapper(Counter c) { 
        this.c = c; 
        this.sub = new SubscriberWrapper(this);
        c.AddObserver(sub);
    }
    public void DoIt(int start, int end) { c.DoIt(start, end); }
}

public delegate void CountEventHandler(int n);

public class SubscriberWrapper : Observer {
    private CounterWrapper c;
    public SubscriberWrapper(CounterWrapper c) {this.c = c;}
    public void Feedback(int n){
        c.CountEvent.Invoke(n);
    }
}
