using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Menu
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IngredientList { get; set; }
        public double Price { get; set; }

        public Menu(int number, string name, string description, string ingredientList, double price)
        {
            Number = number;
            Name = name;
            Description = description;
            IngredientList = ingredientList;
            Price = price;
        }

        public Menu()
        {

        }
    }
}
