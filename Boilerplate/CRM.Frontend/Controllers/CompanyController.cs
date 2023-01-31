using CRM.BLL.Contracts;
using CRM.DAL.Contracts;
using CRM.Domain.Entities;
using CRM.Domain.Request.Company;
using CRM.Domain.ValueObjects;
using CRM.Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Frontend.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyFacade companyFacade;
        public CompanyController(ICompanyFacade companyFacade)
        {
            this.companyFacade = companyFacade;
        }
        //Not decorated with an annotation, this means that this is by default httpget
        public IActionResult Index()
        {
            CompaniesVM model = new CompaniesVM(new List<Company>());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany()
        {
            //get the input from the form elements in the view, denoted by the "name=" attribute
            string name = Request.Form["companyName"];
            string email = Request.Form["email"];
            string street = Request.Form["street"];
            string city = Request.Form["city"];
            string zipcode = Request.Form["zipcode"];
            //create the create company request
            CreateCompanyRequest createCompanyRequst = new CreateCompanyRequest();
            createCompanyRequst.Name = name;
            createCompanyRequst.Street = street;
            createCompanyRequst.Email = email;
            createCompanyRequst.City = city;
            createCompanyRequst.ZipCode = zipcode;
            //save
            await this.companyFacade.CreateCompany(createCompanyRequst);
            //redirect to the index page
            return RedirectToAction("Index");
        }
    }
}
