using Project_A;

namespace Project_A.Classes
{
    public class University
    {
        public string Name { get; set; }
        public int Founded { get; set; }
        public Monitor monitor { get; set; }

        public List<Works> Labs;

        public University(string name, int founded, Monitor monitor)
        {
            throw new NotImplementedException();
        }
    }
}
