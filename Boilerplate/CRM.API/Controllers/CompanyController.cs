using CRM.API.Utilities;
using CRM.BLL.Contracts;
using CRM.Domain.Dto;
using CRM.Domain.Request.Company;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : BaseController
    {
        private readonly ICompanyFacade companyFacade;
        public CompanyController(ICompanyFacade companyFacade)
        {
            this.companyFacade = companyFacade;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody]CreateCompanyRequest request)
        {
            var result = await this.companyFacade.CreateCompany(request);
            return FromResult(result);
        }

        [HttpGet]
        public IEnumerable<CompanyDto> GetCompanies()
        {
            //return this.companyFacade.
            return null;
        }
    }
}
