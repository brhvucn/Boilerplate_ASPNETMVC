using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Request.Company
{
    public class CreateCompanyRequest : IRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        public class Validator : AbstractValidator<CreateCompanyRequest>
        {
            public Validator()
            {
                //implement the business rules for this incoming request
                RuleFor(company => company.Name).NotEmpty();
                RuleFor(company => company.Email).EmailAddress();
                RuleFor(company => company.Street).NotEmpty();
                RuleFor(company => company.City).NotEmpty();
                RuleFor(company => company.ZipCode).NotEmpty().Length(4); //we have a business rule for max 4 characters in the zip code. This is a danish zip code.                
            }
        }
    }
}
