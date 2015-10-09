using System;
using System.Reflection;

struct Point { 
    public int x, y;
    
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public int GetX() { return x; }

    public int GetY() { return y; }
    
}

class Student {
    public int nr;
    public string name;
    public Student(int nr, string name) {
        this.nr = nr;
        this.name = name;
    }
    
    public void Print() {
        Console.WriteLine("nr = {0}, name = {1}", nr, name);
    }
}


class App{

    static void Inspect(object o) {
        Console.WriteLine("Type of o = {0}", o.GetType());
        MemberInfo[] members = o.GetType().GetMembers();
        foreach(MemberInfo m in members) {
            Console.WriteLine(
                "Member name: {0}, type: {1}", 
                m.Name, 
                m.MemberType);
        }
    }
    
    static void Log(object o) {
        FieldInfo[] fs = o.GetType().GetFields();
        MethodInfo[] mis = o.GetType().GetMethods();
        string fieldRes = "";
        string returnRes = "";
        foreach(FieldInfo f in fs){
            fieldRes += string.Format(
                "{0} : {1}, ", 
                f.Name, 
                f.GetValue(o)); // o é target
        }
        foreach (MethodInfo mi in mis) {
            if (mi.GetParameters().Length == 0 && mi.ReturnType != typeof(void)) {
                returnRes += string.Format(
                    "{0} : {1}, ", 
                    mi.Name, 
                    mi.Invoke(o, null)); // o é target
            }
        }
        Console.WriteLine("Fields = " + fieldRes);
        Console.WriteLine("Methods = " + returnRes);
    }
    
	static void Main()
	{
        Student s = new Student(763514, "Ze Manel");
        //Inspect(s);
        Console.WriteLine(s);
        Log(s);
        
        Point p = new Point(5,7);
        Log(p);
        Console.WriteLine(p); 
	}
} 