using WebAssignment.Models;

namespace WebAssignment.Services
{
    public class ProductService : IProductService
    {

        private static List<Product> _products = new List<Product> 
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000 },
            new Product { Id = 2, Name = "Smartphone", Price = 20000 }
        };

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            product.Id = _products.Count + 1; // Generate ID
            _products.Add(product);
        }

    }
}
