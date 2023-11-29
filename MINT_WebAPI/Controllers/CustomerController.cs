using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MINT_WebAPI.Managers.CustomerManaging;
using MINT_WebAPI.Models;

namespace MINT_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager) 
        {
            _customerManager = customerManager;
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _customerManager.GetAllCustomers();
                return Ok(customers);
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

        [HttpGet("GetCustomerById")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var customer = _customerManager.GetCustomerById(id);
                return Ok(customer);
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

        [HttpGet("GetCustomerByName")]
        public IActionResult GetCustomerByName(string name)
        {
            try
            {
                var customer = _customerManager.GetCustomerByName(name);
                return Ok(customer);
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

        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer(Customer customer)
        {
            try
            {
                var result = _customerManager.CreateCustomer(customer);
                if (result == 0) return BadRequest(new { Message = "Customer was not created" });
                return Ok(result);
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

        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                var result = _customerManager.UpdateCustomer(customer);
                if (result == 0) return BadRequest(new { Message = "Customer was not updated" });
                return Ok(result);
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

        [HttpDelete("DeleteCustomerById")]
        public IActionResult DeleteCustomerById(int id)
        {
            try
            {
                var result = _customerManager.DeleteCustomerById(id);
                if (result == 0) return BadRequest(new { Message = "Customer was not deleted" });
                return Ok(result);
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
