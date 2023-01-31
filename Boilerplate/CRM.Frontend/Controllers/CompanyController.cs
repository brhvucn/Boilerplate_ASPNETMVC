using CRM.BLL.Contracts;
using CRM.DAL.Contracts;
using CRM.Domain.Entities;
using CRM.Domain.Request.Company;
using CRM.Domain.ValueObjects;
using CRM.Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Frontend.Controllers
{
    public class CompanyController : BaseController
    {
        private ICompanyFacade companyFacade;
        public CompanyController(ICompanyFacade companyFacade)
        {
            this.companyFacade = companyFacade;
        }
        //Not decorated with an annotation, this means that this is by default httpget
        public async Task<IActionResult> Index()
        {
            CompaniesVM model = new CompaniesVM();//create the model
            var companiesResult = await this.companyFacade.GetAllCompanies();//get all the companies
            if (companiesResult.Success) //if we successfully got the companies
            {
                //add the companies to the view model
                model.Companies = companiesResult.Value;
            }
            else
            {
                //show an error message
                ShowErrorMessage(companiesResult.Error.Message);
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteCompany()
        {
            int id = int.Parse(Request.Form["companyid"]);
            await this.companyFacade.DeleteCompany(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditCompany(int id)
        {
            EditCompanyVM model = new EditCompanyVM();
            var companyResult = await this.companyFacade.GetCompany(id);
            if (companyResult.Success)
            {
                model.Company = companyResult.Value;
            }
            else
            {
                model.Company = new Domain.Dto.CompanyDto(); //prevents null exception in view
                ShowErrorMessage(companyResult.Error.Message);
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateCompany()
        {
            int id = int.Parse(Request.Form["id"]);
            string name = Request.Form["name"];
            string street = Request.Form["street"];
            string city = Request.Form["city"];
            string zip = Request.Form["zip"];
            string email = Request.Form["email"];
            //create the update request
            UpdateCompanyRequest request = new UpdateCompanyRequest();
            request.Name = name;
            request.Street = street;
            request.City = city;
            request.ZipCode = zip;
            request.Email = email;
            request.Id = id;
            //update it
            var result = await this.companyFacade.UpdateCompany(request);
            if(result.Failure)
            {
                ShowErrorMessage(result.Error.Message);
            }
            return RedirectToAction("Index");
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
