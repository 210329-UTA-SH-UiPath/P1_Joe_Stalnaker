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
  class ComponentController : ControllerBase
  {
    static List<Component> components = new List<Component>()
        {
        };
    [HttpGet]
    public IEnumerable<Component> Get()
    {
      return components;
    }
    [HttpPost]
    public IActionResult Post(Component component)
    {
      if (component != null)
      {
        components.Add(component);
        return NoContent();
      }
      else
      {
        return BadRequest("check data, null or invalid");
      }
    }
    [HttpPut]
    public IActionResult Put(Component component)
    {
      var componentFind = components.Find(x => x.ID == component.ID);
      if (componentFind != null)
      {
        components.Add(component);
        return NoContent();
      }
      else
      {
        return BadRequest("check data, null or invalid");
      }
    }
  }
}