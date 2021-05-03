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
    class OrderController : ControllerBase
    {
        static List<Order> orders = new List<Order>() {};

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return orders;
        }
        [HttpPost]
        public IActionResult Post(Order order)
        {
            if (order != null)
            {
                orders.Add(order);
                return NoContent();
            }
            else
            {
                return BadRequest("check data, null or invalid");
            }
        }
        [HttpPut]
        public IActionResult Put(Order order)
        {
            var customerFind = orders.Find(x => x.ID == order.ID);
            if (customerFind != null)
            {
                orders.Add(order);
                return NoContent();
            }
            else
            {
                return BadRequest("check data, null or invalid");
            }
        }
    }
}
