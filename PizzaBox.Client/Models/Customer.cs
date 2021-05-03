using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Service.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
