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
    [Authorize]
    public class CustomersController : ControllerBase
    {

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = ServiceLogics.CustomerManager.Add(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAllCustomers()
        {
            var list = ServiceLogics.AddressManager.GetCountries();
            var result = ServiceLogics.CustomerManager.GetCustomers();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("countries")]
        public IActionResult GetAllCountries()
        {
            return Ok(ServiceLogics.AddressManager.GetCountries());
        }

        [HttpPost("addall")]
        public IActionResult AddCustomer()
        {
            try
            {
                var customer = new Customer { DisplayName = "name", Title = "title", Email = "email",TaxOffice="taxOffice",PhoneNumber="phone" };
                ServiceLogics.CustomerManager.Add(customer);
                ServiceLogics.CustomerManager.Add(customer);
                return Ok("Kayıt Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}