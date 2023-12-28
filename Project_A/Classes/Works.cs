using Project_A;

public delegate void LabCompletedEventHandler(string labName, int grade);

namespace Project_A.Classes
{
    public class Works : IPrintable
    {
        public Student Student { get; set; }
        public string LabName { get; set; }
        public int Date { get; set; }
        public Action<string, int> LabCompleted;

        public Predicate<int> IsPassingGrade;

        public Func<string, bool> LabNameValidator;
        public Works(Student student, string labname, int date)
        {
            Student = student;
            LabName = labname;
            Date = date;
            LabCompleted += HandleLabCompleted;
            IsPassingGrade = grade => grade >= 60;
            LabNameValidator = ValidateLabName;
        }

        private void HandleLabCompleted(string labName, int grade)
        {
            Console.WriteLine($"Лабораторна {labName} завершена з балом {grade}.");
        }

        private bool ValidateLabName(string labName)
        {
            return labName.Length > 0;
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
