using System;
using System.Collections.Generic;

class A<Tx, Ty> {
    public void m<Tm>(Tm z) { 
        
    }
    public void f<Tf>(Tx x, Tf r)
    {
        Tf obj = (Tf) Activator.CreateInstance(typeof(Tf));
    }
}

class B : A<String, Student> { }

class C : A<String, Student> { }

class Student { }

class Account { 
}

class Program{
	static void Main(){
        List<Student> stds = new List<Student>();
        List<Account> accs = new List<Account>();
        
    
        A<string, Student> a1 = new A<string, Student>();
       
        a1.f<Student>("isel", new Student());
        a1.f("isel", new Student()); // O Tf é inferido a partir do 2º argumento
	}
}