using System;
	
public delegate void DowjonesEventHandler(string title, string uri, DateTime when);
	
public class SubscriberWrapper : Subscriber 
{		
    private DowjonesEventHandler handler;//chain delegate

	public void add(DowjonesEventHandler handler)
	{
		this.handler+=handler;
	}
		
	public void remove(DowjonesEventHandler handler)
	{
		this.handler-=handler;
	}

    public void Occurrence(string title, string uri, DateTime when)
    {
		if(this.handler!=null) //verifica se a lista de invocacao esta vazia
			this.handler.Invoke(title, uri, when); //invocar cadeia de delegates
    }
}
	

public class DowjonesEventWrapper
{
		
	private  DowjonesNews djn = new DowjonesNews();
		
	private SubscriberWrapper subs = new SubscriberWrapper(); //wrapper de subscribers
		
	public DowjonesEventWrapper()
	{
		 djn.AddSubscriber(subs); //subscrever no publisher o multicast delegate(handler) através do wrapper de subscribers 
	}	
		
	public void AddHandler(DowjonesEventHandler handler ) 
	{
		this.subs.add(handler);
	}
		
	public void RemoveHandler(DowjonesEventHandler handler) 
	{
		this.subs.remove(handler);
	}		
				
	public void Pull()
	{
		djn.Pull();//notificar subscritores presentes no multicast delegate (chamada a "subs.Occurrence")		
	}

		
}	
	

