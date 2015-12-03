using System;
using System.Windows.Forms;

public class Dummy {
    public void Foo(object n) {
        Console.WriteLine("Foo " + n);
    }
    public void Bar(int n) {
        MessageBox.Show("Bar = " + n);
    }
    static void Main() {}
}

public class Register {
    int acc = 9;
    public void sum(int n) {
        acc += n;
        Console.WriteLine("acc = " + acc);
    }
}