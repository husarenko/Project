namespace Project_A
{
    public abstract class PersonBase
    {
        public abstract string NameStudent { get; set; }
        public abstract int Group { get; set; }
        public abstract int Grade { get; set; }
        public abstract void DisplayInfo();
        public abstract void Study();
    }
}
