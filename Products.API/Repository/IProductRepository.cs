using Products.API.Models;

namespace Products.API.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(Guid id);

        public IEnumerable<Product> GetProductsByAmount(double amount);
        public bool AddProduct(Product product);
        public Product UpdateProduct(Guid id, Product product);
        public bool DeleteProduct(Guid id);

    }
}
