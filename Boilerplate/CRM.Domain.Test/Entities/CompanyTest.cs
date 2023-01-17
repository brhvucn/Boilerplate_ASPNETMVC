using CRM.Domain.Entities;
using CRM.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Test.Entities
{
    public class CompanyTest
    {
        [Fact]
        public void Ctor_Company_ShouldThrowException_EmptyName()
        {
            var email = Email.Create("test@test.com");
            Assert.Throws<ArgumentException>(()=>new Company("", email));
        }

        [Fact]
        public void Ctor_Company_ShouldThrowException_NullEmail()
        {
            Assert.Throws<ArgumentNullException>(() => new Company("test", null));
        }

        [Fact]
        public void Ctor_Company_Pass() 
        {
            //arrange
            var email = Email.Create("test@test.com");
            //act
            var company = new Company("My Company", email);
            //assert
            Assert.True(company != null);
        }
    }
}
