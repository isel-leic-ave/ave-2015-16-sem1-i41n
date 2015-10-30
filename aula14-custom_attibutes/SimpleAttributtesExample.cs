using System;

[AttributeUsage(AttributeTargets.Method |
    AttributeTargets.Class |
    AttributeTargets.Field |
    AttributeTargets.Property,
    AllowMultiple=true
    )]
class AuthorAttribute : Attribute {
	public AuthorAttribute(String name) { 
		this.Name = name; 
		this.StartDate = "undefined";
	}
	public String Name { get; set; }
	public String StartDate { get; set; }
}

[AuthorAttribute("Jose", StartDate="1/1/2015")]
[Author("Manuel", StartDate="1/6/2015")]
//[MyAttribute]
public class A {

   	private readonly int a=10;

	public static void M(String s, out int a) {
		//s[1] = 'a';
		s = "abc";
		a = 10;
	}

   public static void Main() {

   		String x1 = "xpto";
   		int x2 ;

   		M(x1, out x2);

   		Console.WriteLine("{0} {1}", x1, x2);

   		Console.WriteLine(Attribute.IsDefined(typeof(A), typeof(AuthorAttribute)));
   		
   		AuthorAttribute[] attrs = (AuthorAttribute[])
   			Attribute.GetCustomAttributes(typeof(A), typeof(AuthorAttribute));
   		
   		foreach (AuthorAttribute author in attrs) {
   			Console.WriteLine(author.GetHashCode());
   			Console.WriteLine(author.Name);   			
   			Console.WriteLine(author.StartDate);   			
   		}

   		attrs[0].Name = "Joao";

		Console.WriteLine("************************************************");

   		attrs = (AuthorAttribute[])
   			Attribute.GetCustomAttributes(typeof(A), typeof(AuthorAttribute));
   		
   		foreach (AuthorAttribute author in attrs) {
   			Console.WriteLine(author.GetHashCode());
   			Console.WriteLine(author.Name);   			
   			Console.WriteLine(author.StartDate);   			
   		}

   }


}