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
            throw new NotImplementedException();
        }

        public void PrintToDisplay()
        {
            throw new NotImplementedException();
        }
    }
}
