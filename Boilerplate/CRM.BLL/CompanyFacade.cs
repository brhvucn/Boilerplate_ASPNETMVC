using AutoMapper;
using CRM.BLL.Contracts;
using CRM.DAL.Contracts;
using CRM.Domain.Common;
using CRM.Domain.Dto;
using CRM.Domain.Entities;
using CRM.Domain.Request.Company;
using Microsoft.Extensions.Logging;

namespace CRM.BLL
{
    public class CompanyFacade : ICompanyFacade
    {
        private ICompanyRepository companyRepository;
        private IMapper mapper;
        private ILogger<CompanyFacade> logger;
        public CompanyFacade(ICompanyRepository companyRepository, IMapper mapper, ILogger<CompanyFacade> logger)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Result<CompanyDto>> CreateCompany(CreateCompanyRequest request)
        {
            //validate the request
            CreateCompanyRequest.Validator validator = new CreateCompanyRequest.Validator();
            var result = validator.Validate(request);
            if(result.IsValid)
            {
                //continue to create
                Company company = this.mapper.Map<Company>(request);
                var companyResult = await this.companyRepository.CreateAsync(company);
                CompanyDto dtoResult = this.mapper.Map<CompanyDto>(companyResult);
                return Result.Ok<CompanyDto>(dtoResult);
            }
            else
            {
                string errormessages = string.Join(Environment.NewLine, result.Errors);
                return Result.Fail<CompanyDto>(Errors.General.CouldNotValidateBusinessLogic(errormessages));
            }
        }

        public async Task<List<CompanyDto>> GetAllCompanies()
        {
            //get all the companies, then convert them to the corresponding dto
            var companies = await this.companyRepository.GetAllAsync();
            //create the list to return
            List<CompanyDto> result = new List<CompanyDto>();
            return result;
        }
    }
}