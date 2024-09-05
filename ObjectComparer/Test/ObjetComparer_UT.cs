using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectComparer;

namespace Test
{
    [TestClass]
    public class ObjetComparer_UT
    {
        [TestMethod]
        public void ObjectComparer_CompareTwoSameIntegerValue_ReturnsTrue()
        {
            var result = DeepComparer.CompareObject(1234, 1234);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ObjectComparer_CompareTwoDifferentIntegerValue_ReturnsFalse()
        {
            var result = DeepComparer.CompareObject(123, 1234);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ObjectComparer_CompareTwoSameStringValue_ReturnsTrue()
        {
            var result = DeepComparer.CompareObject("TestString1", "TestString1");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ObjectComparer_CompareTwoDifferentStringValue_ReturnsFalse()
        {
            var result = DeepComparer.CompareObject("TestString1", "TestString2");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ObjectComparer_CompareTwoSameArrayValue_ReturnsTrue()
        {
            int[] marks1 = { 55, 56, 60, 100, 99 };
            int[] marks2 = { 99, 100, 55, 60, 56 };
            var result = DeepComparer.CompareObject(marks1, marks2);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ObjectComparer_CompareTwoDifferentArrayValue_ReturnsFalse()
        {
            int[] marks1 = { 55, 56, 55, 100, 99 };
            int[] marks2 = { 55, 100, 55, 60, 56 };
            var result = DeepComparer.CompareObject(marks1, marks2);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ObjectComparer_CompareTwoSimilarObject_ReturnsTrue()
        {
            //Arrange
            var Student1 = new
            {
                Name = "John",
                Marks = new int[] { 100, 56, 78, 76, 90 },
                Subjects = new string[] {"Math","Science","General","Computer","Sanskrit"} 
            };
            var Student2 = new
            {
                Name = "John",
                Marks = new int[] { 100, 56, 78, 76, 90 },
                Subjects = new string[] { "Math", "Science", "General", "Computer", "Sanskrit" }
            };

            //Act
            var result = DeepComparer.CompareObject(Student1, Student2);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ObjectComparer_CompareTwoDifferentObject_ReturnsFalse()
        {
            var Student1 = new
            {
                Name = "John",
                Marks = new int[] { 77, 56, 78, 76, 90 },
                Subjects = new string[] { "Math", "Science", "General", "Computer", "Sanskrit" }
            };
            var Student2 = new
            {
                Name = "John",
                Marks = new int[] { 100, 56, 78, 76, 90 },
                Subjects = new string[] { "Math", "Science", "General", "Computer", "Sanskrit" }
            };
            var result = DeepComparer.CompareObject(Student1, Student2);
            Assert.IsFalse(result);
        }
    }
}