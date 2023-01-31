using AutoMapper;
using CRM.BLL.Contracts;
using CRM.DAL.Contracts;
using CRM.Domain.Common;
using CRM.Domain.Dto;
using CRM.Domain.Entities;
using CRM.Domain.Request.Company;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace CRM.BLL
{
    //the purpose of this class is to perform the business log sourrounding the logic in the application.
    public class CompanyFacade : ICompanyFacade
    {
        private ICompanyRepository companyRepository;
        private IMapper mapper; //helps us map from one object to another
        private ILogger<CompanyFacade> logger; //enables us to log, using the built in logging mechanism.
        public CompanyFacade(ICompanyRepository companyRepository, IMapper mapper, ILogger<CompanyFacade> logger)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Creates a new company. The first thing to do is to validate the request. If the request is valid then we can continue to map to the right entity, insert it into the database and create the result by mapping back to a type. This will return the inserted object with the new id assigned to it
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Result<CompanyDto>> CreateCompany(CreateCompanyRequest request)
        {
            try
            {
                //validate the request
                CreateCompanyRequest.Validator validator = new CreateCompanyRequest.Validator();
                var result = validator.Validate(request); //validate business rules
                if (result.IsValid)
                {
                    //continue to create
                    Company company = this.mapper.Map<Company>(request); //automatically map from CreateCompanyRequest to Company
                    var companyResult = await this.companyRepository.CreateAsync(company); //create in the database
                    CompanyDto dtoResult = this.mapper.Map<CompanyDto>(companyResult);//automatically map from Company to CompanyDto
                    return Result.Ok<CompanyDto>(dtoResult); //create a result and return it
                }
                else
                {
                    this.logger.LogError("Error Creating company: " + string.Join(Environment.NewLine, result.Errors));
                    string errormessages = string.Join(Environment.NewLine, result.Errors);
                    return Result.Fail<CompanyDto>(Errors.General.CouldNotValidateBusinessLogic(errormessages));
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<CompanyDto>(Errors.General.FromException(ex));
            }
        }

        public async Task DeleteCompany(int id)
        {
            //depending on the business logic, perhaps we should check that we can actually delete the company. Sometimes according to business logic
            //an entity may not be deleted if there are other objects attached to it (e.g. invoices, contacts, etc.)
            await this.companyRepository.DeleteAsync(id);
        }

        public async Task<Result<IEnumerable<CompanyDto>>> GetAllCompanies()
        {
            try
            {
                //get all the companies, then convert them to the corresponding dto
                var companies = await this.companyRepository.GetAllAsync();
                //create the list to return
                IEnumerable<CompanyDto> result = this.mapper.Map<IEnumerable<CompanyDto>>(companies);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<IEnumerable<CompanyDto>>(Errors.General.FromException(ex));
            }
        }

        public async Task<Result<CompanyDto>> GetCompany(int id)
        {
            try
            {
                //get a single company from the repository, convert it and return it
                var company = await this.companyRepository.GetFromIdAsync(id);
                var companyDto = this.mapper.Map<CompanyDto>(company);
                return Result.Ok(companyDto);
            }
            catch (Exception ex)
            {
                return Result.Fail<CompanyDto>(Errors.General.FromException(ex));
            }
        }

        public async Task<Result> UpdateCompany(UpdateCompanyRequest request)
        {
            try
            {
                //validate the request
                UpdateCompanyRequest.Validator validator = new UpdateCompanyRequest.Validator();
                var result = validator.Validate(request); //validate business rules
                if (result.IsValid)
                {
                    //continue to create
                    Company company = this.mapper.Map<Company>(request); //automatically map from UpdateCompanyRequest to Company                    
                    await this.companyRepository.UpdateAsync(company); //create in the database
                    return Result.Ok();
                }
                else
                {
                    this.logger.LogError("Error Updating company: " + string.Join(Environment.NewLine, result.Errors));
                    string errormessages = string.Join(Environment.NewLine, result.Errors);
                    return Result.Fail(Errors.General.CouldNotValidateBusinessLogic(errormessages));
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<CompanyDto>(Errors.General.FromException(ex));
            }
        }
    }
}