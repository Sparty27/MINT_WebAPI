using Microsoft.AspNetCore.Mvc;

namespace MINT_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
