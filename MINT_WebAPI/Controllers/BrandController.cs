using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MINT_WebAPI.Managers.BrandManaging;

namespace MINT_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandManager _brandManager;

        public BrandController(IBrandManager brandManager) 
        {
            _brandManager = brandManager;   
        }

        [HttpGet("GetBrands")]
        public IActionResult GetAllBrands()
        {
            try
            {
                var brands = _brandManager.GetAllBrands();
                foreach (var item in brands)
                {
                    Console.WriteLine("Here are brands: ");
                    Console.WriteLine(item.BrandName);
                }
                return Ok(brands);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Problem with database");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
