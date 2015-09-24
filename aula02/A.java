import java.lang.*; // opcional

class A extends Object{

	int x, y;
	
    public A() {
        super();
    }

	void m(){
		/* Just a dummy method */
	}

}

class B{

	C w = new C();

	class C{}
    
    public static void main(String [] args) {
        System.out.println("Ola");
    }
}