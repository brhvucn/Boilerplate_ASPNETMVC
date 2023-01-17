using CRM.Domain.Entities;
using CRM.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Test.Entities
{
    public class ContactTest
    {
        [Fact]
        public void Ctor_Company_ShouldThrowException_EmptyName()
        {
            var email = Email.Create("test@test.com");
            Assert.Throws<ArgumentException>(() => new Contact("", email));
        }

        [Fact]
        public void Ctor_Company_ShouldThrowException_NullEmail()
        {
            Assert.Throws<ArgumentNullException>(() => new Contact("test", null));
        }

        [Fact]
        public void Ctor_Company_Pass()
        {
            //arrange
            var email = Email.Create("test@test.com");
            //act
            var contact = new Company("My Contact", email);
            //assert
            Assert.True(contact != null);
        }
    }
}
