using System;
using System.Collections;
using System.Reflection;

public class TPC04 { 

	public static void Main(String[] args) {

		Type[] types = Assembly.LoadFrom(args[0]).GetTypes();
		foreach (Type t in types) {
			object o = Activator.CreateInstance(t);
			MethodInfo[] methods = t.GetMethods(
				BindingFlags.Instance |
				BindingFlags.Static   |
				BindingFlags.Public   |
				BindingFlags.DeclaredOnly
			);
			foreach(MethodInfo mi in methods) {
	        	object[] parameters = GetDefaultValuesForParameters(mi.GetParameters());
				Console.WriteLine("Calling {0}", mi.Name);
				mi.Invoke(mi.IsStatic? null: o, parameters);
			}
		}
	}

	private static object[] GetDefaultValuesForParameters(ParameterInfo[] paramTypes)
    {
        Object[] parameters = new Object[paramTypes.Length];
        for (int i = 0; i < paramTypes.Length; i++)
        {
            parameters[i] = Activator.CreateInstance(paramTypes[i].ParameterType);
        }
        return parameters;
    }

}
