using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using EntityCustomer.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            
            if (result.Result.Success)
            {
                return Ok(result.Result.Message);
            }

            return BadRequest(result.Result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAllCustomers()
        {
            var result = _customerService.GetCustomers();
            if (result.Result.Success)
            {
                return Ok(result.Result.Data);
            }

            return BadRequest(result.Result.Message);
        }
    }
}