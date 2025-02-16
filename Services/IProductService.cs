using WebAssignment.Models;
namespace WebAssignment.Services
{

    public interface IProductService
    {
        List<Product> GetAllProducts(); 
        void AddProduct(Product product); 
    }

}
