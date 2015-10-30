using System;

class SimpleAttribute : Attribute {
  public int value;
  public SimpleAttribute(int value){
      this.value = value; 
  }
}

[SimpleAttribute(5)]
class Demo {  }

class App { 

  static void DecAndShowAttribute(Demo d) {
    SimpleAttribute attr1 = (SimpleAttribute)
       Attribute.GetCustomAttribute(d.GetType(), typeof(SimpleAttribute));
    if (attr1.value == 0) return;
    Console.WriteLine(attr1.value--);
    DecAndShowAttribute(d);
  }

  static void Main() {
    DecAndShowAttribute(new Demo());
  }
}


