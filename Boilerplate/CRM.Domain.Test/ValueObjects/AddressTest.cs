using CRM.Domain.ValueObjects;
using CRM.UnitTest.Helpers.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Test.ValueObjects
{    
    public class AddressTests
    {
        [Fact]
        public void Create_Valid_Address()
        {
            string street = StringRandom.GetRandomString(10);
            string city = StringRandom.GetRandomString(10);
            string zipcode = StringRandom.GetRandomString(10);
            var email = Address.Create(street, city, zipcode);
            Assert.True(email.Success);
        }

        [Theory]
        [InlineData("", "testcity", "testzip")]
        [InlineData("teststreet", "", "testzip")]
        [InlineData("teststreet", "testcity", "")]
        public void Create_Invalid_Address_EmptyParameter(string street, string city, string zipcode)
        {
            Action action = new Action(() => Address.Create(street, city, zipcode));
            Assert.Throws<ArgumentException>(action);
        }
    }
}
