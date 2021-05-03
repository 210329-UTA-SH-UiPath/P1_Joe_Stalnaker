using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Service.Models
{
    public class Order
    {
    public int ID { get; set; }
    public AStore Store { get; set; }
    public Customer Customer { get; set; }
    public List<APizza> Pizzas { get; set; }
    public DateTime DateTime { get; set; }
    public Order() : base() { }
    }
}
