using System;

class Dummy{}

abstract class Student{
    static int nrOfStudents;

    static Student() {
        nrOfStudents = 37;
    }
    
    const string SECRET = "ldfljldjfa�skf�aksgj";
    // const Dummy BAR = new Dummy(); // Dummy n�o � represent�vel num literal
    
    readonly Dummy BAR = new Dummy();
    
    public int Nr{get; set;}
    public abstract string  Name {get; set;}
    
}

class App {
    static void Main() {
    }
}