using System;
/*
 * Representa um recurso "caro", que uitiliza muitos sockets, MEM, etc
 */
class ServiceProvider {
    public ServiceProvider() {
        Console.WriteLine("######### Instiatiating a new Service Provider");
    }
    public void doWork(){
        Console.WriteLine("Working....");
    }
}

class ServiceWrapper {
    WeakReference<ServiceProvider> provider;
    
    public void doWork(){
        ServiceProvider service;
        if((provider == null) || !provider.TryGetTarget(out service)){
            service = new ServiceProvider();
            provider = new WeakReference<ServiceProvider>(service); // !!!!! podem evitar instanciar uma nova WeakReference fazendo o SetTarget(T)
        }
        service.doWork();
    }
}

class App {
    static void Main() {
        ServiceWrapper service = new ServiceWrapper();
        Console.WriteLine("Setup finished... Press enter to start");
        Console.ReadLine();
        service.doWork(); // Instanciar um ServiceProvider + Working 
        service.doWork(); // Working 
        service.doWork(); // Working 
        GC.Collect();
        service.doWork(); // Instanciar um ServiceProvider + Working 
        service.doWork(); // Working 
    }
}