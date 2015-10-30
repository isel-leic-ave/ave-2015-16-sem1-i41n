
class D {
   public static void M4() { }
   public static void M5(E e) { }
}
class E { public static void M6() { } }


class A { public void M1(B b, C c) { c.M3(); } }

class B { public void M2() { } }

class C { public void M3() { D.M4(); } }


class Program {
 static void Main() {
  new A().M1(null, new C());
 }
}



