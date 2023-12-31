﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MINT_WebAPI.Managers.BrandManaging;
using MINT_WebAPI.Models;

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

        [HttpGet("GetBrandById")]
        public IActionResult GetBrandById(int id)
        {
            try
            {
                var brand = _brandManager.GetBrandById(id);
                if (brand == null) return BadRequest(new { Message = "Brand was not found"});
                return Ok(brand);
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

        [HttpGet("GetBrandByName")]
        public IActionResult GetBrandByName(string name)
        {
            try
            {
                var brand = _brandManager.GetBrandByName(name);
                if (brand == null) return BadRequest(new { Message = "Brand was not found" });
                return Ok(brand);
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

        [HttpPost("CreateBrand")]
        public IActionResult CreateBrand(Brand brand)
        {
            try
            {
                var result = _brandManager.CreateBrand(brand);
                if (result == 0) return BadRequest(new { Message = "Brand was not created" });
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

        [HttpPut("UpdateBrand")]
        public IActionResult UpdateBrand(Brand brand)
        {
            try
            {
                var result = _brandManager.UpdateBrand(brand);
                if (result == 0) return BadRequest(new { Message = "Brand was not updated" });
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

        [HttpDelete("DeleteBrandById")]
        public IActionResult UpdateBrand(int id)
        {
            try
            {
                var result = _brandManager.DeleteBrandById(id);
                if (result == 0) return BadRequest(new { Message = "Brand was not deleted" });
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
