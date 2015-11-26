using System;

class Dummy{}

abstract class Student{
    static int nrOfStudents;

    static Student() {
        nrOfStudents = 37;
    }
    
    const string SECRET = "ldfljldjfaçºskfºaksgj";
    // const Dummy BAR = new Dummy(); // Dummy não é representável num literal
    
    readonly Dummy BAR = new Dummy();
    
    public int Nr{get; set;}
    public abstract string  Name {get; set;}
    
}

class App {
    static void Main() {
    }
}