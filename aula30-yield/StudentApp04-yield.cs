using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class Student
{
    public readonly int nr;
    public readonly string name;
    public readonly int selected;
    public readonly int grade;

    public Student(int nr, String name, int selected, int grade)
    {
        this.nr = nr;
        this.name = name;
        this.selected = selected;
        this.grade = grade;
    }

    public override String ToString()
    {
        return String.Format("{0} {1} ({2}, {3})", nr, name, selected, grade);
    }
    public void Print()
    {
        Console.WriteLine(this);
    }
    
    public static Student Parse(string src){
        string [] words = src.Split('|');
        return new Student(
            int.Parse(words[1]),
            words[2],
            int.Parse(words[3]),
            int.Parse(words[4]));
    }
}

static class App
{
    private static readonly String STUDENTS_FILE = "..\\00-raffle\\isel-ave-2015-16-sem1-listagem.txt";

    static IEnumerable<Student> StudentsFrom(string path) {
        return Select(WithLines(path), line => Student.Parse(line));
    }
    
    static List<String> WithLines(string path)
    {
        string line;
        List<string> res = new List<string>();
        using (StreamReader file = new StreamReader(path, Encoding.UTF8)) // <=> try-with resources do Java >= 7
        {
            while ((line = file.ReadLine()) != null)
            {
                res.Add(line);
            }
        }
        return res;
    }

    static IEnumerable<R> Select<T, R>(this IEnumerable<T> src, Func<T, R> proj)
    {
        foreach(T item in src){
            yield return proj(item);
        }
    }
    static IEnumerable<T> Where<T>(this IEnumerable<T> src, Predicate<T> p)
    {
        foreach(T item in src){
            if(p(item)) yield return item;
        }
    }
    static IEnumerable<T> Top<T>(this IEnumerable<T> src, int total)
    {
        int i = 0;
        foreach(T item in src){
            if(i == total) break;
            i++;
            yield return item;
        }
    }
    
    static void ForEach<T>(this IEnumerable<T> src, Action<T> a){
        foreach(T item in src){
            a(item);
        }
    }
    
    static IEnumerable<T> Distinct<T>(this IEnumerable<T> src){ 
        HashSet<T> itens = new HashSet<T>();
        foreach(T item in src){
            if(itens.Add(item))
                yield return item;
        }
    }
    
    static IEnumerable<T> Skip<T>(this IEnumerable<T> src, int count) {
        int i = 0;
        foreach(T item in src){
            if(i++ >= count) 
                yield return item;
        }

    }
    
    static void Print(string label, Object item){
        Console.WriteLine(label + ": " + item);
    }
    
    static void Main()
    {
        // Print("ALL: ", WithLines(STUDENTS_FILE));
        IEnumerable<Student> stds = StudentsFrom(STUDENTS_FILE);
        int iter = 0;
        IEnumerable<string> res = stds
            .Where(s =>
            {
                iter++;
                // Print("Filtering", s.nr); 
                return s.grade < 10;
            })
            .Select(s =>
            {
                iter++;
                // Print("Parsing", s.nr); 
                return s.name.Split(' ')[0].ToLower();
            })
            .Distinct()
            .Skip(3)
            .Top(10);
        
        res.ForEach(name => Console.WriteLine(">>>>>>>>>>>>>>>>>>>" + name));

        Console.WriteLine(iter);           
    }
}