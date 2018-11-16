using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    class ProgramUI
    {
        CustomerRepository _customerRepo = new CustomerRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            Console.WriteLine("Welcome to the Komodo Insurance Email System Manager\n" +
            "Please add a customer to the email list\n");
            AddCustomer();
            Console.Clear();
            bool running = true;
            while (running)
            {
                Console.WriteLine("Main Menu\n\n" +
                    "What would you like to do?\n" +
                    "1. Create new customer\n" +
                    "2. Update customer information\n" +
                    "3. Remove customer from email list\n" +
                    "4. Display current email list\n" +
                    "5. Exit");

                int input = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (input)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        UpdateInfo();
                        break;
                    case 3:
                        RemoveCustomer();
                        break;
                    case 4:
                        DisplayList();
                        Console.Clear();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Response");
                        break;
                }
            }
        }

        private void AddCustomer()
        {
            Customer newCustomer = new Customer();
            Console.WriteLine("Is this customer a...\n" +
                "1. Current customer,\n" +
                "2. Past customer, or\n" +
                "3. Potential customer");
            int customerTypeInput = int.Parse(Console.ReadLine());

            switch (customerTypeInput)
            {
                case 1:
                    newCustomer.CustomerType = CustomerType.Current;
                    newCustomer.EmailResponse = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case 2:
                    newCustomer.CustomerType = CustomerType.Past;
                    newCustomer.EmailResponse = "It's been a long time since we've heare from you, we want you back!";
                    break;
                case 3:
                    newCustomer.CustomerType = CustomerType.Potential;
                    newCustomer.EmailResponse = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
            }

            Console.WriteLine("First name:");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("Last name:");
            newCustomer.LastName = Console.ReadLine();

            _customerRepo.AddCustomer(newCustomer);

            Console.Clear();
        }

        private void RemoveCustomer()
        {
            List<Customer> customerList = _customerRepo.GetCustomerList();

            Console.WriteLine("Here is the current list of all customers in the database.");
            DisplayList();

            Console.WriteLine("Please enter the first name of the customer you would like to remove");
            string firstNameInput = Console.ReadLine();

            Console.WriteLine("Now, please enter their last name");
            string lastNameInput = Console.ReadLine();

            foreach (Customer customer in customerList)
            {
                if (firstNameInput == customer.FirstName && lastNameInput == customer.LastName)
                {
                    _customerRepo.RemoveCustomer(customer);
                    break;
                }
            }
            Console.WriteLine($"Customer {firstNameInput} {lastNameInput} has been removed from the list.");

            Console.Clear();
        }

        private void DisplayList()
        {
            List<Customer> customerList = _customerRepo.GetCustomerList();
            Console.WriteLine("First\tLast \t\tType\t\tEmail");
            var orderedList = customerList.OrderBy(c => c.LastName).ToList();
            foreach (Customer customer in orderedList)
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private void UpdateInfo()
        {
            List<Customer> customerList = _customerRepo.GetCustomerList();

            Console.WriteLine("Here is the current list of all customers in the database.");
            DisplayList();

            Console.WriteLine("Please enter the first name of the customer you would like to update");
            string firstNameInput = Console.ReadLine();

            Console.WriteLine("Now, please enter their last name");
            string lastNameInput = Console.ReadLine();

            foreach (Customer customer in customerList)//?
            {
                if (firstNameInput == customer.FirstName && lastNameInput == customer.LastName)
                {
                    _customerRepo.RemoveCustomer(customer);
                    break;
                }
            }

            Console.Clear();

            Customer newCustomer = new Customer();

            Console.WriteLine("Please enter the new customer information./n");
            Console.WriteLine("Is this customer a...\n" +
                "1. Current customer,\n" +
                "2. Past customer, or\n" +
                "3. Potential customer");
            int customerTypeInput = int.Parse(Console.ReadLine());

            switch (customerTypeInput)
            {
                case 1:
                    newCustomer.CustomerType = CustomerType.Current;
                    break;
                case 2:
                    newCustomer.CustomerType = CustomerType.Past;
                    break;
                case 3:
                    newCustomer.CustomerType = CustomerType.Potential;
                    break;
            }

            Console.WriteLine("First name:");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("Last name: ");
            newCustomer.LastName = Console.ReadLine();

            _customerRepo.AddCustomer(newCustomer);

            Console.Clear();
        }
    }
}
