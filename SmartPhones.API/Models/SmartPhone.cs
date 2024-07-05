using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SmartPhones.API.Models
{
    public class SmartPhone
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Features { get; set; }

        [Required]
        public DateTime LaunchDate { get; set; }

        [Range(500,10000000000,ErrorMessage="Price must be greater than 500")]
        public double Price { get; set; }

        
    }
}
