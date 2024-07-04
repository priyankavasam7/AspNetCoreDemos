namespace Products.API.Models
{
    public class Product
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

    }
}
