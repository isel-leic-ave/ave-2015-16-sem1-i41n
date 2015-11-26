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

    static List<Student> StudentsFrom(string path) {
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

    static List<R> Select<T, R>(List<T> src, Func<T, R> proj){
        List<R> res = new List<R>();
        foreach(T item in src){
            res.Add(proj(item));
        }
        return res; 
    }
    static List<T> Where<T>(List<T> src, Predicate<T> p){
        List<T> res = new List<T>();
        foreach(T item in src){
            if(p(item)) res.Add(item);
        }
        return res; 
    }
    static List<T> Top<T>(List<T> src, int total){
        int i = 0;
        List<T> res = new List<T>();
        foreach(T item in src){
            if(i == total) break;
            i++;
            res.Add(item);
        }
        return res; 
    }
    static void ForEach<T>(List<T> src, Action<T> a){
        foreach(T item in src){
            a(item);
        }
    }
    
    static void Print(string label, Object item){
        Console.WriteLine(label + ": " + item);
    }
    
    static void Main()
    {
        // Print("ALL: ", WithLines(STUDENTS_FILE));
        List<Student> stds = StudentsFrom(STUDENTS_FILE);
        
        ForEach(
            Select(
                Top(
                    Where(
                        stds,
                        s => s.grade >= 10),
                    5), 
                s => s.name),
            name => Console.WriteLine(name));
           
           
/* 
        int iter = 0;
        Foreach(
            Top(
                Where(
                    Select( 
                        WithLines(STUDENTS_FILE), 
                        line => { iter++; Print("Parsing", line); return Student.Parse(line);}), 
                    s => { iter++; Print("Filtering", s.nr); return s.grade >= 10;}), 
                5), 
            Console.WriteLine);
*/
    }
}