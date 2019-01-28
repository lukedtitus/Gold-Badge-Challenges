using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    class CustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();

        public List<Customer> GetCustomerList()
        {
            return _customerList;
        }

        public List<Customer> GetSortedCustomerList()
        {
            _customerList.OrderBy(i => i.LastName).ToList();
            return _customerList;
        }

        public void AddCustomer(Customer customer)
        {
            _customerList.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            _customerList.Remove(customer);
        }
    }
}
