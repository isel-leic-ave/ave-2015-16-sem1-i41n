class A{}
class B extends A {}

class App {
    public static void main(String[] args) {
        A a = new A();
        B b = new B();
        
        System.out.println("a is compatible with A = " + (a instanceof A));
        System.out.println("a is instance of class A = " + (a.getClass() == A.class));
        System.out.println("b is compatible with A = " + (b instanceof A));
        Class k2 = b.getClass();
        System.out.println("b is instance of class A = " + (k2 == A.class));
    }
}



