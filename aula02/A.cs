using System;  // using <=> import do Java. System java.lang

class A{

	int x, y;
	    
	void m(){
		/* Just a dummy method */
	}

}

class B{

	C w = new C();

	class C{}
    
    public static void Main(String [] args) {
        Console.WriteLine("Ola");
    }
}