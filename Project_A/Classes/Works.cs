using Project_A;

namespace Project_A.Classes
{
    public class Works : IPrintable
    {
        public Student Student { get; set; }
        public string LabName { get; set; }
        public int Date { get; set; }

        public Works(Student student, string labname, int date)
        {
            Student = student;
            LabName = labname;
            Date = date;
        }

        public void PrintToDisplay()
        {
            Console.WriteLine($"Назва лабораторної: {LabName}");
            Console.WriteLine($"Дата: {Date}");
            Console.WriteLine("Iнфрмацiя про студента: ");
            Student.DisplayInfo();
        }
    }
}
