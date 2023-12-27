using Project_A;

namespace Project_A.Classes
{
    public class Monitor : PersonBase, IPerson
    {
        public override string NameStudent { get; set; }
        public int MainGroup { get; set; }
        public int Faculty { get; set; }
        public List<Student> Students { get; set; }

        public Monitor(string nameStudent, int mainGroup, int faculty)
        {
            NameStudent = nameStudent;
            MainGroup = mainGroup;
            Faculty = faculty;
            Students = new List<Student>();
        }

        public override int Group
        {
            get { return MainGroup; }
            set { MainGroup = value; }
        }

        public override int Grade
        {
            get { return 0; }
            set { throw new InvalidOperationException("Старости не мають балів"); }
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"I'мя старости: {NameStudent}");
            Console.WriteLine($"Група: {MainGroup}");
            Console.WriteLine($"Факультет: {Faculty}");
        }
        public override void Study()
        {
            Console.WriteLine($"{NameStudent} є старостою групи {MainGroup}.");
        }
        
    }
}
