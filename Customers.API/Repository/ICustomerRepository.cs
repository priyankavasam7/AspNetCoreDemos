using Customers.API.Models;

namespace Customers.API.Repository
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetCustomerById(Guid id);
        public bool AddCustomer(Customer customer);
        public Customer UpdateCustomer(Guid id, Customer customer);
        public bool DeleteCustomer(Guid id);
        
    }
}
