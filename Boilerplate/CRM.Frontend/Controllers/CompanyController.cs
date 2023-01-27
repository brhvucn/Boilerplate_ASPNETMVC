using CRM.Domain.Entities;
using CRM.Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Frontend.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            CompaniesVM model = new CompaniesVM(new List<Company>());
            return View(model);
        }
    }
}
