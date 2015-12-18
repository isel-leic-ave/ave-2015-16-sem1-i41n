using System;
using System.IO;

static class App{

    class FileStreamClean : FileStream{
        public FileStreamClean(string path) : base(path, FileMode.Create) {}
        ~FileStreamClean(){ throw new Exception("Breaking Finalize"); }
    }

    static void PrintRunningGC(){
        Console.WriteLine("Running GC...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

	public static void Main(){
        
        // 
        // Uma instância de FileStream mantém um handle para um recurso nativo, i.e. um ficheiro.
        //
        FileStream fs = new FileStreamClean("out.txt");
		// Wait for user to hit <Enter>
        Console.WriteLine("Wait for user to hit <Enter>");
		Console.ReadLine();
		
        // PrintRunningGC();
        
        // <=> Java close() 
        // Faz o mesmo que o Finalize. Mas o Finalize() é chamado pela VM e NÃO explicitamente pelo programador.
        // !!!!!! Não forçar GC.Collect() e em GC.WaitForPendingFinalizers();
        // O Dispose() é a API disponibilizada ao programador
        // Só o Dipose() é permitido ao programdor
        Console.WriteLine("Filestream disposed....");
        fs.Dispose(); 
        
        Console.WriteLine("Wait for user to hit <Enter>");
		Console.ReadLine();
        
	}
    
}
