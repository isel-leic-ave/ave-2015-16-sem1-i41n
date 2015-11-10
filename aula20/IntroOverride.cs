

using System;

class A {
	public virtual void M() { Console.WriteLine("A.M()"); }
	public void T()         { Console.WriteLine("A.T()"); }
}

class C : A {

}

class D : C {
	int field=1;
	public override void M() { Console.WriteLine("C.M()"); }
}

class Program {
	static void Main() {
		A a = new D();
		a.M();

		C c = (C) a;
		c.M();
	}
}