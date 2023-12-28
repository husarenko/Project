using Project_A.Classes;
using Project_A;

namespace ArtGalleryClass.Tests
{
    [TestClass]
    public class ArtGalleryTests
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
            Assert.AreEqual(monitor, university.monitor);
            Assert.IsNotNull(university.Labs);
            Assert.IsInstanceOfType(university.Labs, typeof(List<Works>));
        }

        [TestMethod]
        public void WorksImplementsIPrintable_InterfaceTest()
        {
            Works lab1 = new Works(new Student("Meshkov", 512, 37, LabCourse.IP), "IP1", 2022);

            Assert.IsTrue(lab1 is IPrintable);
        }
    }
}
