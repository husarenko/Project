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
            Console.WriteLine("-----Передбачення полiморфiзму-----\nВарiант 1: об’єкти похiдного класу обробляються як об’єкти базового\r\nкласу (в параметрах методiв, в колекцiях та iн.);");
            
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

                int choice;
                do
                {
                    Console.WriteLine("=== Панель керування університетом ===");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Add Lab Work");
                    Console.WriteLine("3. Показати всі лабораторні");
                    Console.WriteLine("4. Показати всіх студентів");
                    Console.WriteLine("0. Вихід");
                    Console.Write("Введіть значення: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
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
            Console.WriteLine("=== Додати студениа ===");
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
                        Console.WriteLine("Додано!");
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
            Console.WriteLine("=== Додати лабораторну ===");
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
                        Console.WriteLine("Лаба додана!");
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
    }
}