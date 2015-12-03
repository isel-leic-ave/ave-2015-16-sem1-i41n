using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        Counter c = new Counter();

        // c.obs += value => Console.WriteLine("ConsoleHandler = " + value);
        // c.obs += value => MessageBox.Show("Item = " + value);
        
        if(args.Length != 0) 
            c.AddObserversFrom(args[0]);
            
        c.DoIt(5, 7);
    }
}

public delegate void Observer(int value);

class Counter {
    /* Gera:
     *   * um par de métodos: add_obs e remove_obs
     *   * um campo privado obs do tipo Observer
     *   * um membro evento obs do tipo Observer
     * 
     * A acessibilidade estabelece a acessibilidade dos métodos add_obs e remove_obs
     */
    public event Observer obs;
    private string path;
    
    public void NotifyObservers(int n) {
        if(obs != null) obs(n); // <=> obs.Invoke(n);
    }

    // Notifica o método de callback Feedback do objecto o,
    // por cada iteração de from a to.
    public void DoIt(int from, int to) {
        for (int i = from; i <= to; i++) {
            NotifyObservers(i);
        }
    }
    
    public void AddObserversFrom(string path){
        this.path = path;
        obs += NotifyObserversFrom;
    }
    public void NotifyObserversFrom(int n) {
        Type[] klasses = Assembly.LoadFrom(path).GetTypes();
        foreach(Type t in klasses) {
            object target = Activator.CreateInstance(t);
            foreach(MethodInfo m in t.GetMethods()) {
                ParameterInfo[] args = m.GetParameters();
                if(m.ReturnType == typeof(void) && args.Length == 1 && args[0].ParameterType.IsAssignableFrom(typeof(int)))
                    m.Invoke(target, new object[1]{n});
            }   
        }
    }
}
