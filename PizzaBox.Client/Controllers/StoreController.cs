using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PizzaBox.Service.Models;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class StoreController : ControllerBase
    {
        static List<AStore> orders = new List<AStore>() { };

        [HttpGet]
        public IEnumerable<AStore> Get()
        {
            return orders;
        }
        [HttpPost]
        public IActionResult Post(AStore order)
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
        public IActionResult Put(AStore order)
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
