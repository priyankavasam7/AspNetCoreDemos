using Microsoft.EntityFrameworkCore;
using SmartPhones.API.Models;

namespace SmartPhones.API.Data
{
    public class SmartPhoneDbContext : DbContext
    {
        public SmartPhoneDbContext(DbContextOptions options):base(options) { }
        public DbSet<SmartPhone> smartPhones { get; set; }
    }

}
