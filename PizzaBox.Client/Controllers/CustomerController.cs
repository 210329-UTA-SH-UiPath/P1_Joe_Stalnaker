using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PizzaBox.Service.Models;

namespace PizzaBox.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class CustomerController : ControllerBase
    {
        static List<Customer> customers = new List<Customer>()
        {
            new Customer() { ID=1, Name="John", Orders= new List<Order>() }
        };
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customers;
        }
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (customer != null)
            {
                customers.Add(customer);
                return NoContent();
            }
            else
            {
                return BadRequest("check data, null or invalid");
            }
        }
        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            var customerFind = customers.Find(x => x.ID == customer.ID);
            if (customerFind != null)
            {
                customers.Add(customer);
                return NoContent();
            }
            else
            {
                return BadRequest("check data, null or invalid");
            }
        }
    }
}