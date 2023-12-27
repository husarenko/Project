using Project_A;
using System;

namespace Project_A.Classes
{
    public class Student : PersonBase, IClonable
    {
        public override string NameStudent { get; set; }
        public override int Group { get; set; }
        public override int Grade { get; set; }
        public LabCourse LabCourse { get; set; }
        public Student(string nameStudent, int group, int grade, LabCourse labCourse)
        {
            NameStudent = nameStudent;
            Group = group;
            Grade = grade;
            LabCourse = labCourse;
        }
        public object Clone()
        {
            return new Student(NameStudent, Group, Grade, LabCourse);
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Ім'я студента: {NameStudent}");
            Console.WriteLine($"Група: {Group}");
            Console.WriteLine($"Рейтинговий бал: {Grade}");
            Console.WriteLine($"Course: {LabCourse}");
        }
        public override void Study()
        {
            Console.WriteLine($"{NameStudent} пише лабораторну з {LabCourse}.");
        }
    }
}
