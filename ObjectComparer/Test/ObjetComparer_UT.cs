using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectComparer;
using System.Xml.Linq;

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
                Subjects = new string[] { "Math", "Science", "General", "Computer", "Sanskrit" },
                Cources = new List<object>() { new {
                                                        Name = "Course1",
                                                        Passed = true,
                                                    },
                                                new {
                                                        Name = "Course2",
                                                        Passed = false,
                                                    } 
                                              }
                
            };
            var Student2 = new
            {
                Name = "John",
                Marks = new int[] { 90, 56, 78, 76, 100 },
                Subjects = new string[] { "Math", "Science", "General", "Computer", "Sanskrit" },
                Cources = new List<object>() { new {
                                                        Name = "Course2",
                                                        Passed = false,
                                                    },
                                                new {
                                                        Name = "Course1",
                                                        Passed = true,
                                                    }   
                                              }
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
        [TestMethod]
        public void ObjectComparer_CompareTwoDictinaryWithPrimitiveTypeKeyAndValue_ReturnsTrue()
        {
            Dictionary<string, string> dict1 = new Dictionary<string, string>();
            dict1.Add("Key1", "Value1");
            dict1.Add("Key2", "Value2");
            dict1.Add("Key3", "Value3");
            dict1.Add("Key4", "Value4");
            dict1.Add("Key5", "Value5");
            Dictionary<string, string> dict2 = new Dictionary<string, string>();
            dict2.Add("Key4", "Value4");
            dict2.Add("Key5", "Value5");
            dict2.Add("Key1", "Value1");
            dict2.Add("Key2", "Value2");
            dict2.Add("Key3", "Value3");
            var result = DeepComparer.CompareObject(dict1, dict2);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ObjectComparer_CompareTwoDictinaryWithPrimitiveTypeKeyAndValue_ReturnsFalse()
        {
            Dictionary<string, string> dict1 = new Dictionary<string, string>();
            dict1.Add("Key1", "Value1");
            dict1.Add("Key2", "Value2");
            dict1.Add("Key3", "Value4");
            dict1.Add("Key4", "Value5");
            dict1.Add("Key5", "Value6");
            Dictionary<string, string> dict2 = new Dictionary<string, string>();
            dict2.Add("Key4", "Value5");
            dict2.Add("Key5", "Value6");
            dict2.Add("Key1", "Value1");
            dict2.Add("Key2", "Value2");
            dict2.Add("Key9", "Value9");
            var result = DeepComparer.CompareObject(dict1, dict2);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ObjectComparer_CompareTwoDictinaryWithPrimitiveTypeKeyAndRefernceTypeValue_ReturnsTrue()
        {
            Dictionary<string, object> dict1 = new Dictionary<string, object>();
            dict1.Add("Person1", new { Name = "TATA", Address = new List<string>() {"Delhi","Tata","Mumbai" } });
            dict1.Add("Person2", new { Name = "Birla", Address = new List<string>() { "Up", "Mumbai", "Goa" } });

            Dictionary<string, object> dict2 = new Dictionary<string, object>();
            dict2.Add("Person2", new { Name = "Birla", Address = new List<string>() { "Up", "Mumbai", "Goa" } });
            dict2.Add("Person1", new { Name = "TATA", Address = new List<string>() { "Mumbai", "Tata", "Delhi" } });

            var result = DeepComparer.CompareObject(dict1, dict2);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ObjectComparer_CompareTwoDictinaryWithPrimitiveTypeKeyAndReferenceTypeValue_ReturnsFalse()
        {
            Dictionary<string, object> dict1 = new Dictionary<string, object>();
            dict1.Add("Person1", new { Name = "TATA", Address = new List<string>() { "Delhi", "Tata", "Mumbai" } });
            dict1.Add("Person2", new { Name = "Birla", Address = new List<string>() { "Up", "Mumbai", "Goa" } });

            Dictionary<string, object> dict2 = new Dictionary<string, object>();
            dict2.Add("Person2", new { Name = "Birla", Address = new List<string>() { "Up", "Mumbai" } });
            dict2.Add("Person1", new { Name = "TATA", Address = new List<string>() { "Mumbai", "Tata", "Delhi" } });

            var result = DeepComparer.CompareObject(dict1, dict2);
            Assert.IsFalse(result);
        }
    }
}