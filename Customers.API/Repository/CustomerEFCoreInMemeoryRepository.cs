using Customers.API.Data;
using Customers.API.Models;

namespace Customers.API.Repository
{
    public class CustomerEFCoreInMemeoryRepository : ICustomerEFRepository
    {
        CustomerDbContext _customerDbContext;
        public CustomerEFCoreInMemeoryRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public bool AddCustomer(CustomerEFCore customer)
        {
            if (customer != null)
            {
                _customerDbContext.Customers.Add(customer);
                _customerDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(int id)
        {
            var customer=GetCustomerById(id);
            if (customer != null)
            {
                _customerDbContext.Customers.Remove(customer);
                _customerDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<CustomerEFCore> GetAllCustomers()
        {
            return _customerDbContext.Customers;
        }

        public CustomerEFCore GetCustomerById(int id)
        {
            var customer= _customerDbContext.Customers.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public CustomerEFCore UpdateCustomer(int id, CustomerEFCore customer)
        {
            var existingCcustomer= GetCustomerById(id);
            if (existingCcustomer != null)
            {
                existingCcustomer.Name = customer.Name;
                existingCcustomer.Email = customer.Email;
                _customerDbContext.SaveChanges();
                return existingCcustomer;
            }
            return null;
        }
    }
}
