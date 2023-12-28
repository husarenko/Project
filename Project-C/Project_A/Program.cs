using Project_A.Classes;
using Project_A;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Project (part B)\n");
            Console.WriteLine("-----Передбачення поліморфізму-----\nВаріант 1: об’єкти похідного класу обробляються як об’єкти базового класу (в параметрах методів, в колекціях та ін.);");

            List<PersonBase> people = new List<PersonBase>();

            Student student = new Student("John Doe", 621, 90, LabCourse.Math);
            Project_A.Classes.Monitor monitor = new Project_A.Classes.Monitor("Jane Doe", 621, 6);

            people.Add(student);
            people.Add(monitor);

            foreach (PersonBase person in people)
            {
                Console.WriteLine($"Iм'я: {person.NameStudent}, Група: {person.Group}");
            }

            Console.WriteLine("------------------");

            foreach (PersonBase person in people)
            {
                person.DisplayInfo();
                person.Study();
                Console.WriteLine("------------------");
            }
            Console.WriteLine();
            Console.WriteLine("=== Інформація щодо університету ===");
            Console.Write("Введіть назву університету: ");
            string universityName = Console.ReadLine();

            Console.Write("Рік заснування: ");
            if (int.TryParse(Console.ReadLine(), out int foundedYear))
            {
                University university = new University(universityName, foundedYear, CreateMonitor());
                university.DisplayUniversityInfo();
                Console.WriteLine("------------------");

                int choice;
                do
                {
                    DisplayMenu(); // Виведення оновленого меню
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        HandleMenuChoice(choice, university);
                    }
                    else
                    {
                        Console.WriteLine("Невірний тип даних.");
                    }

                    Console.WriteLine();
                } while (choice != 0);
            }
            else
            {
                Console.WriteLine("Невірний тип даних.");
            }
        }

        // Оновлене меню
        static void DisplayMenu()
        {
            Console.WriteLine("=== Панель керування університетом ===");
            Console.WriteLine("1. Додати студента");
            Console.WriteLine("2. Додати лабораторну роботу");
            Console.WriteLine("3. Показати всі лабораторні");
            Console.WriteLine("4. Показати всіх студентів");
            Console.WriteLine("0. Вихід");
            Console.Write("Введіть значення: ");
        }

        // Обробка вибору користувача
        static void HandleMenuChoice(int choice, University university)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddStudent(university);
                    break;
                case 2:
                    Console.Clear();
                    AddLabWork(university);
                    break;
                case 3:
                    Console.Clear();
                    DisplayAllLabs(university);
                    break;
                case 4:
                    Console.Clear();
                    DisplayAllStudents(university);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }

        static Project_A.Classes.Monitor CreateMonitor()
        {
            Console.WriteLine("=== Інформація про старосту ===");
            Console.Write("Введіть ім'я старости: ");
            string monitorName = Console.ReadLine();

            Console.Write("Введіть групу старости: ");
            if (int.TryParse(Console.ReadLine(), out int mainGroup))
            {
                Console.Write("Введіть факультет старости: ");
                if (int.TryParse(Console.ReadLine(), out int faculty))
                {
                    return new Project_A.Classes.Monitor(monitorName, mainGroup, faculty);
                }
                else
                {
                    Console.WriteLine("Невірний тип даних.");
                    Environment.Exit(0);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Невірний тип даних.");
                Environment.Exit(0);
                return null;
            }
        }


        static void AddStudent(University university)
        {
            Console.WriteLine("=== Додати студента ===");
            Console.Write("Ім'я студента: ");
            string name = Console.ReadLine();

            Console.Write("Група: ");
            if (int.TryParse(Console.ReadLine(), out int group))
            {
                Console.Write("Рейтинг: ");
                if (int.TryParse(Console.ReadLine(), out int grade))
                {
                    Console.Write("Курс (Math, OOP, ASP, IP): ");
                    if (Enum.TryParse(Console.ReadLine(), out LabCourse labCourse))
                    {
                        Student student = new Student(name, group, grade, labCourse);
                        university.AddStudent(student);
                    }
                    else
                    {
                        Console.WriteLine("Такого курсу не існує.");
                    }
                }
                else
                {
                    Console.WriteLine("Невірний тип даних.");
                }
            }
            else
            {
                Console.WriteLine("Невірний тип даних.");
            }
        }

        static void AddLabWork(University university)
        {
            Console.WriteLine("=== Додати лабораторну роботу ===");
            Console.Write("Ім'я лабораторної роботи: ");
            string labName = Console.ReadLine();

            Console.Write("Дата: ");
            if (int.TryParse(Console.ReadLine(), out int date))
            {
                Console.WriteLine("Вибір студента:");
                university.DisplayStudents();
                Console.Write("Введіть індекс студента: ");
                if (int.TryParse(Console.ReadLine(), out int studentNumber))
                {
                    if (university.Students.Count > studentNumber && studentNumber >= 0)
                    {
                        Student selectedStudent = university.Students[studentNumber];
                        Works labWork = new Works(selectedStudent, labName, date);
                        university.AddLab(labWork);
                    }
                    else
                    {
                        Console.WriteLine("Такого індекса не існує.");
                    }
                }
                else
                {
                    Console.WriteLine("Невірний тип даних.");
                }
            }
            else
            {
                Console.WriteLine("Невірний тип даних.");
            }
        }


        static void DisplayAllLabs(University university)
        {
            Console.WriteLine("=== Усі лабораторні ===");
            foreach (var lab in university.Labs)
            {
                lab.PrintToDisplay();
                Console.WriteLine();
            }
        }

        static void DisplayAllStudents(University university)
        {
            List<Student> allStudents = university.Students;

            if (allStudents.Count == 0)
            {
                Console.WriteLine("Нема жодного студента в університеті.");
                return;
            }

            Console.WriteLine("=== Усі студенти ===");
            foreach (var student in allStudents)
            {
                Console.WriteLine($"Ім'я: {student.NameStudent}, Група: {student.Group}, Grade: {student.Grade}");
                Console.WriteLine();
            }
        }
    
        private static void HandleStudentAdded(object sender, University.StudentEventArgs e)
        {
            Console.WriteLine($"Студента додано: {e.AddedStudent.NameStudent}, Група: {e.AddedStudent.Group}");
        }

        private static void HandleLabAdded(object sender, University.LabEventArgs e)
        {
            Console.WriteLine($"Лабораторну додано: {e.AddedLab.LabName}, Дата: {e.AddedLab.Date}");
        }
    }
}