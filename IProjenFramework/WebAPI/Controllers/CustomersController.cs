using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using EntityCustomer.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomersController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = ServiceLogics.CustomerManager.Add(customer);
            
            if (result.Result.Success)
            {
                return Ok(result.Result.Message);
            }

            return BadRequest(result.Result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAllCustomers()
        {
            var result = ServiceLogics.CustomerManager.GetCustomers();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}