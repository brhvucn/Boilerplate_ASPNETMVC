using Microsoft.AspNetCore.Mvc;

namespace CRM.Frontend.Controllers
{
    public class BaseController : Controller
    {
       protected void ShowErrorMessage(string message)
        {
            TempData["Error"] = message;
        }
    }
}
