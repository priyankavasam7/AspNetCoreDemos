using Customers.API.Models;

namespace Customers.API.Repository
{
    public interface ICustomerEFRepository
    {
        public IEnumerable<CustomerEFCore> GetAllCustomers();
        public CustomerEFCore GetCustomerById(int id);
        public bool AddCustomer(CustomerEFCore customer);
        public CustomerEFCore UpdateCustomer(int id, CustomerEFCore customer);
        public bool DeleteCustomer(int id);
    }
}

