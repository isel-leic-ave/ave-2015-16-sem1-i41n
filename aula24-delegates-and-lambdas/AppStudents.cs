using System;
using System.Collections.Generic;

public class Student {
    public readonly int nr;
    public readonly String name;
    public Student(int nr, String name){
        this.nr = nr;
        this.name = name;
    }
}

// Gera:
// classe ComparatorStudent com um único método Invoke:
//     int Invoke(Student s1, Student s2)
public delegate int ComparatorStudent(Student s1, Student s2);


public class AppStudents {
    public static void sortStudents(List<Student> stds, ComparatorStudent cmp) {
        for(int i = stds.Count -1; i>1; i--){
            for(int j = 0; j < i; j++){
                if(cmp.Invoke(stds[j], stds[i]) > 0) {
                    Student aux = stds[i];
                    stds[i] = stds[j];
                    stds[j] = aux;
                }
            }
        }
    }
    
    public static void Main(String [] args) {
        List<Student> stds = null;
        sortStudents(stds, (s1, s2) => s1.name.CompareTo(s2.name));
    }
}