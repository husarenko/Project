using Project_A;

namespace Project_A.Classes
{
    public class Student
    {
        public string NameStudent { get; set; }
        public int Group { get; set; }
        public int Grade { get; set; }
        public LabCourse LabCourse { get; set; }

        public Student(string NameStudent, int group, int grade, LabCourse labCourse)
        {
            throw new NotImplementedException();
        }
    }
}
