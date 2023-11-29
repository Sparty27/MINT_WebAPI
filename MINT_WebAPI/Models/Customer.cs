using Microsoft.AspNetCore.Mvc;

namespace MINT_WebAPI.Models
{
    public class Customer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
