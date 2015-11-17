import java.util.List;

class Student {
    final int nr;
    final String name;
    public Student(int nr, String name){
        this.nr = nr;
        this.name = name;
    }
}

interface ComparatorStudent {
    int compare(Student s1, Student s2);
}

public class AppStudents {
    public static void sortStudents(List<Student> stds, ComparatorStudent cmp) {
        for(int i = stds.size() -1; i>1; i--){
            for(int j = 0; j < i; j++){
                if(cmp.compare(stds.get(j), stds.get(i)) > 0) {
                    Student aux = stds.get(i);
                    stds.set(i, stds.get(j));
                    stds.set(j, aux);
                }
            }
        }
    }
    
    public static void main(String [] args) {
        List<Student> stds = null;
        sortStudents(stds, (s1, s2) -> s1.name.compareTo(s2.name));
    }
}