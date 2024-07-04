using Customers.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Customers.API.Repository
{
    public class CustomerInMemoryRepository : ICustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();

        public CustomerInMemoryRepository()
        {
            _customerList.Add(new Customer { Name = "Priya", Email = "priya@test.com" });
            _customerList.Add(new Customer { Name = "Yuvi", Email = "yuvi@test.com" });
            _customerList.Add(new Customer { Name = "Giri", Email = "giri@test.com" });
        }

        public bool AddCustomer(Customer customer)
        {
            if (customer == null) return false; 
            _customerList.Add(customer);
            return true;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
           return _customerList;
        }
        public Customer GetCustomerById(Guid id)
        {
            var customer = _customerList.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public Customer UpdateCustomer(Guid id, Customer customer)
        {
            var existingCustomer = _customerList.FirstOrDefault(c => c.Id == id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                return existingCustomer;
            }
            return null;
        }

        public bool DeleteCustomer(Guid id)
        {
            var existingCustomer = _customerList.FirstOrDefault(c => c.Id == id);
            if (existingCustomer != null)
            {
                _customerList.Remove(existingCustomer);
                return true;
            }
            return false;
        }
    }
}
