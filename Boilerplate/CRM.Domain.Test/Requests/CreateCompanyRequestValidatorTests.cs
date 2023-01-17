using CRM.Domain.Request.Company;
using CRM.UnitTest.Helpers.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Test.Requests
{
    public class CreateCompanyRequestValidatorTests
    {
        [Fact]
        public void ValidateRequest_InvalidRequest_Name_ShouldFail()
        {
            //Arrange
            CreateCompanyRequest request = new CreateCompanyRequest()
            {
                City = StringRandom.GetRandomString(10),
                Email = EmailRandom.GetRandomEmail(),
                Name = "",
                Street = StringRandom.GetRandomString(10),
                ZipCode = "abcd"
            };
            //Act
            CreateCompanyRequest.Validator validator = new CreateCompanyRequest.Validator();
            var result = validator.Validate(request);
            //Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Any());
            Assert.True(result.Errors[0].ErrorMessage == "'Name' must not be empty.");
        }

        [Fact]
        public void ValidateRequest_InvalidRequest_City_ShouldFail()
        {
            //Arrange
            CreateCompanyRequest request = new CreateCompanyRequest()
            {
                City = "",
                Email = EmailRandom.GetRandomEmail(),
                Name = StringRandom.GetRandomString(10),
                Street = StringRandom.GetRandomString(10),
                ZipCode = "abcd"
            };
            //Act
            CreateCompanyRequest.Validator validator = new CreateCompanyRequest.Validator();
            var result = validator.Validate(request);
            //Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Any());
            Assert.True(result.Errors[0].ErrorMessage == "'City' must not be empty.");
        }

        [Fact]
        public void ValidateRequest_InvalidRequest_Street_ShouldFail()
        {
            //Arrange
            CreateCompanyRequest request = new CreateCompanyRequest()
            {
                City = StringRandom.GetRandomString(10),
                Email = EmailRandom.GetRandomEmail(),
                Name = StringRandom.GetRandomString(10),
                Street = "",
                ZipCode = "abcd"
            };
            //Act
            CreateCompanyRequest.Validator validator = new CreateCompanyRequest.Validator();
            var result = validator.Validate(request);
            //Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Any());
            Assert.True(result.Errors[0].ErrorMessage == "'Street' must not be empty.");
        }

        [Fact]
        public void ValidateRequest_InvalidRequest_Email_ShouldFail()
        {
            //Arrange
            CreateCompanyRequest request = new CreateCompanyRequest()
            {
                City = StringRandom.GetRandomString(10),
                Email = "fake email",
                Name = StringRandom.GetRandomString(10),
                Street = StringRandom.GetRandomString(10),
                ZipCode = "abcd"
            };
            //Act
            CreateCompanyRequest.Validator validator = new CreateCompanyRequest.Validator();
            var result = validator.Validate(request);
            //Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Any());
            Assert.True(result.Errors[0].ErrorMessage == "'Email' is not a valid email address.");
        }

        [Fact]
        public void ValidateRequest_InvalidRequest_ZipTooShort_ShouldFail()
        {
            //Arrange
            CreateCompanyRequest request = new CreateCompanyRequest()
            {
                City = StringRandom.GetRandomString(10),
                Email = EmailRandom.GetRandomEmail(),
                Name = StringRandom.GetRandomString(10),
                Street = StringRandom.GetRandomString(10),
                ZipCode = "abc"
            };
            //Act
            CreateCompanyRequest.Validator validator = new CreateCompanyRequest.Validator();
            var result = validator.Validate(request);
            //Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Any());
            Assert.True(result.Errors[0].ErrorMessage == "'Zip Code' must be 4 characters in length. You entered 3 characters.");
        }

        [Fact]
        public void ValidateRequest_InvalidRequest_ZipTooLong_ShouldFail()
        {
            //Arrange
            CreateCompanyRequest request = new CreateCompanyRequest()
            {
                City = StringRandom.GetRandomString(10),
                Email = EmailRandom.GetRandomEmail(),
                Name = StringRandom.GetRandomString(10),
                Street = StringRandom.GetRandomString(10),
                ZipCode = "abcde"
            };
            //Act
            CreateCompanyRequest.Validator validator = new CreateCompanyRequest.Validator();
            var result = validator.Validate(request);
            //Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Any());
            Assert.True(result.Errors[0].ErrorMessage == "'Zip Code' must be 4 characters in length. You entered 5 characters.");
        }
    }
}
