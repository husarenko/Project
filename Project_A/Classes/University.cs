using Project_A;

namespace Project_A.Classes
{
    public class University
    {
        public string Name { get; set; }
        public int Founded { get; set; }
        public Monitor Monitor { get; set; }

        public List<Works> Labs { get; set; }
        public List<Student> Students { get; set; }
        public int Group { get; set; }

        public University(string name, int founded, Monitor monitor)
        {
            Name = name;
            Founded = founded;
            Monitor = monitor;
            Students = new List<Student>();
            Labs = new List<Works>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void AddLab(Works lab)
        {
            Labs.Add(lab);
        }

        public void DisplayUniversityInfo()
        {
            Console.WriteLine($"Назва університету: {Name}");
            Console.WriteLine($"Заснований: {Founded}");
            Console.WriteLine("Iнформацiя про старосту:");
            Monitor.DisplayInfo();
        }
        public void DisplayStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine($"Студентів нема.");
                return;
            }

            Console.WriteLine($"=== Students in Group===");
            var groupedStudents = Students.GroupBy(student => student.Group);

            foreach (var group in groupedStudents)
            {
                Console.WriteLine($"Group {group.Key}:");
                foreach (var student in group)
                {
                    student.DisplayInfo();
                    Console.WriteLine("----");
                }
            }
        }
    }
}
