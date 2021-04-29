using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Service.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Menu() { }

        public Menu(int id, string name, string text)
        {
            Text = text;
        }
        public override string ToString()
        {
            return $"{Text}";
        }
    }
}
