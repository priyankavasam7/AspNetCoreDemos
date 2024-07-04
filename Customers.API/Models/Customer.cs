using System.ComponentModel.DataAnnotations;

namespace Customers.API.Models
{
    public class Customer
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
