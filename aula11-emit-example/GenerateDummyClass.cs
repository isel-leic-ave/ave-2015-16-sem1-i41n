using System;
using System.Reflection;
using System.Reflection.Emit;



public class GenerateDummyClass {

	public static void Main(String[] args) {
		// get type descriptor of interface
		Assembly asmLoaded = Assembly.LoadFrom(args[0]);
		Type baseType = asmLoaded.GetType(args[1]);
		if (!baseType.IsInterface) {
			throw new ArgumentException("Type " + baseType.Name + " is not an interface");
		}
		// define assemly name
		AssemblyName aName = new AssemblyName("MyType");
		// create assembly builder
        AssemblyBuilder ab =
            AppDomain.CurrentDomain.DefineDynamicAssembly(
                aName,
                AssemblyBuilderAccess.Save);

        // For a single-module assembly, the module name is usually 
        // the assembly name plus an extension.
        ModuleBuilder mb =
            ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");

        // start type definition
        TypeBuilder tb = mb.DefineType("MyType", TypeAttributes.Public);

        tb.AddInterfaceImplementation(baseType);

        MethodInfo[] baseMethods = baseType.GetMethods();
        foreach (MethodInfo mi in baseMethods) {
        	// convert ParameterInfo to Type
        	Type[] parameterTypes = new Type[mi.GetParameters().Length];
        	for (int i=0; i<parameterTypes.Length; ++i) {
        		parameterTypes[i] = mi.GetParameters()[i].ParameterType;
        	}
        	// define new method
	        MethodBuilder meth = tb.DefineMethod(
	            mi.Name,
	            MethodAttributes.Public | MethodAttributes.Virtual,
	            mi.ReturnType,
	            parameterTypes);        	
	        // Generate code
	        ILGenerator gen = meth.GetILGenerator();
	        if (mi.ReturnType == typeof(void)) {
	        	gen.Emit(OpCodes.Ret);
	        } else if (mi.ReturnType.IsClass) {
	        	gen.Emit(OpCodes.Ldnull);
	        	gen.Emit(OpCodes.Ret);
	        } else {
	        	throw new ArgumentException("Return type is not supported");
	        }
        }
        tb.CreateType();
        ab.Save(aName.Name + ".dll");
	}
}