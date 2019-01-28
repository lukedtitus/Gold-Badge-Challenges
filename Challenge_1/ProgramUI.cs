using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("Hello restaurant manager. What would you like to do?" +
                    "\n1. Create a new menu item" +
                    "\n2. Delete a menu item" +
                    "\n3. Display current menu" +
                    "\n4. Exit program");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateMenuItem();
                        break;
                    case 2:
                        RemoveMenuItem();
                        break;
                    case 3:
                        DisplayMenuContents();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response.");
                        break;
                }
            }
        }

        private void CreateMenuItem()
        {
            Console.Clear();

            Menu newItem = new Menu();
            Console.WriteLine("What is the desired meal number?");
            newItem.Number = int.Parse(Console.ReadLine());

            Console.WriteLine("\nWhat would you like to call this meal?");
            newItem.Name = Console.ReadLine();

            Console.WriteLine("\nPlease entere a meal description.");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("\nPlease enter all of the ingredients for your meal.");
            newItem.IngredientList = Console.ReadLine();

            Console.WriteLine("\nWhat is your desired meal price? \n(Please match this format; 5.99)");
            newItem.Price = double.Parse(Console.ReadLine());

            _menuRepo.AddItemToMenu(newItem);
        }

        private void DisplayMenuContents()
        {
            Console.Clear();

            List<Menu> menu = _menuRepo.GetMenuList();
            foreach (Menu items in menu)
            {
                Console.WriteLine($"Item number: {items.Number}\n" +
                    $"Name: {items.Name}\n" +
                    $"Description: {items.Description}\n" +
                    $"Ingredients: {items.IngredientList}\n" +
                    $"Price: {items.Price}\n");
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private void DisplayMenuContentsInRemoveMethod()
        {
            List<Menu> menu = _menuRepo.GetMenuList();
            foreach (Menu items in menu)
            {
                Console.WriteLine($"Item number: {items.Number}\n" +
                    $"Name: {items.Name}\n" +
                    $"Description: {items.Description}\n" +
                    $"Ingredients: {items.IngredientList}\n" +
                    $"Price: {items.Price}\n");
            }
        }

        private void RemoveMenuItem()
        {
            Console.Clear();

            List<Menu> menu = _menuRepo.GetMenuList();
            Console.WriteLine("Here is your current menu." +
                "Please enter the menu number of the item you would like to delete.");
            DisplayMenuContentsInRemoveMethod();
            int userInput = int.Parse(Console.ReadLine());

            foreach (Menu item in menu)
            {
                if (item.Number == userInput)
                {
                    _menuRepo.RemoveItemFromMenu(item);
                    break;
                }
            }

            Console.WriteLine($"You have deleted item number {userInput} from the list.\n" +
                $"Press enter to continue...");
            Console.ReadLine();
        }
    }
}
