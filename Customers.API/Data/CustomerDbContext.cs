using Customers.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Data
{
    public class CustomerDbContext : DbContext
    {
        /*
         * 1. Create a application db context class which inherits the DbContext class of EF Core
         * 2. Add an overloaded constructor with DbContextOptions as parameter.
         * 3. Create a DbSet<modelclass>
         * 4. Register the application db Context in the services collection.
         */
        public CustomerDbContext(DbContextOptions options) : base(options)
        {

            
        }
        public DbSet<CustomerEFCore> Customers { get; set; }
    }
}
