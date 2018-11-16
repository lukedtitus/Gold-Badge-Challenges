using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public enum CustomerType
    {
        None,
        Current = 1,
        Past,
        Potential
    }

    class Customer
    {
        public CustomerType CustomerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailResponse { get; set; }

        public Customer(CustomerType customerType, string firstName, string lastName, string emailResponse)
        {
            CustomerType = customerType;
            FirstName = firstName;
            LastName = lastName;
            EmailResponse = emailResponse;
        }

        public override string ToString()
        {
            return $"{FirstName}\t{LastName}\t{CustomerType}\t\t{EmailResponse}";
        }

        public Customer()
        {

        }
    }
}
