using System;

class MockClass {

}

class A {
	public void m_a(int a, int b) { Console.WriteLine("I'm m_a"); }
}

class B {
	public void m_b(MockClass m) { Console.WriteLine("I'm m_b"); }
}