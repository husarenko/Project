using Project_A.Classes;
using Project_A;

namespace UniversityClass.Tests
{
    [TestClass]
    public class UniversityClassTests
    {
        [TestMethod]
        public void CreateStudent_ValidateProperties()
        {
            Student student = new Student("Kevlarov", 621, 79, LabCourse.Math);

            Assert.AreEqual("Kevlarov", student.NameStudent);
            Assert.AreEqual(621, student.Group);
            Assert.AreEqual(79, student.Grade);
            Assert.AreEqual(LabCourse.Math, student.LabCourse);
        }

        [TestMethod]
        public void CreateWorks_ValidateProperties()
        {
            Student student1 = new Student("Petrenko", 622, 67, LabCourse.OOP);
            Works works = new Works(student1, "OOP2", 2022);

            Assert.AreEqual(student1, works.Student);
            Assert.AreEqual("OOP2", works.LabName);
            Assert.AreEqual(2022, works.Date);
        }

        [TestMethod]
        public void CreateUniversity_ValidateProperties()
        {
            Project_A.Classes.Monitor monitor = new Project_A.Classes.Monitor("Loper", 611, 6);
            University university = new University("KHAI", 1950, monitor);

            Assert.AreEqual("KHAI", university.Name);
            Assert.AreEqual(1950, university.Founded);
            Assert.AreEqual(monitor, university.Monitor);
            Assert.IsNotNull(university.Labs);
            Assert.IsInstanceOfType(university.Labs, typeof(List<Works>));
        }

        [TestMethod]
        public void WorksImplementsIPrintable_InterfaceTest()
        {
            Works lab1 = new Works(new Student("Meshkov", 512, 37, LabCourse.IP), "IP1", 2022);

            Assert.IsTrue(lab1 is IPrintable);
        }

        [TestMethod]
        public void CreateMonitor_ValidateProperties()
        {
            Project_A.Classes.Monitor monitor = new Project_A.Classes.Monitor("Ivanov", 601, 5);

            Assert.AreEqual("Ivanov", monitor.NameStudent);
            Assert.AreEqual(601, monitor.MainGroup);
            Assert.AreEqual(5, monitor.Faculty);
        }

        [TestMethod]
        public void AddStudentToUniversity_Success()
        {
            University university = new University("Test University", 2000, new Project_A.Classes.Monitor("Monitor", 600, 6));
            Student student = new Student("TestStudent", 601, 80, LabCourse.ASP);

            university.AddStudent(student);

            Assert.IsTrue(university.Students.Contains(student));
        }

        [TestMethod]
        public void AddLabToUniversity_Success()
        {
            University university = new University("Test University", 2000, new Project_A.Classes.Monitor("Monitor", 600, 6));
            Student student = new Student("TestStudent", 601, 80, LabCourse.ASP);
            Works lab = new Works(student, "ASP1", 2022);

            university.AddLab(lab);

            Assert.IsTrue(university.Labs.Contains(lab));
        }
        
        [TestMethod]
        public void AddStudentToUniversity_ShouldAddStudentToList()
        {
            University university = new University("Test University", 2023, new Project_A.Classes.Monitor("Test Monitor", 1, 1));
            Student student = new Student("Test Student", 1, 90, LabCourse.Math);
            university.AddStudent(student);
            Assert.AreEqual(1, university.Students.Count);
            Assert.AreEqual(student, university.Students[0]);
        }
    }
}
