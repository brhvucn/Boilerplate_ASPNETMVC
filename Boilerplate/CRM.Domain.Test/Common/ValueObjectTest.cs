using CRM.Domain.Test.TestEntities;

namespace CRM.Domain.Test.Common
{
    public class ValueObjectTest
    {
        [Fact]
        public void TestCreateObjectExpectTheSame()
        {
            //Arrange
            var testObj1 = new TestValueObject() { Name = "My Name", Description = "My Desc", Age = 10 };
            var testObj2 = new TestValueObject() { Name = "My Name", Description = "My Desc", Age = 10 };
            //Act + Assert
            Assert.True(testObj1 == testObj2);
        }

        [Fact]
        public void TestCreateObjectExpectDifferent()
        {
            //Arrange
            var testObj1 = new TestValueObject() { Name = "My Name differs", Description = "My Desc", Age = 10 };
            var testObj2 = new TestValueObject() { Name = "My Name", Description = "My Desc", Age = 10 };
            //Act + Assert
            Assert.False(testObj1 == testObj2);
        }
    }
}