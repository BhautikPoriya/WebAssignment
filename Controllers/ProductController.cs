using Microsoft.AspNetCore.Mvc;
using WebAssignment.Models;
using WebAssignment.Services;

namespace WebAssignment.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProducts()
        {
            var products = _productService.GetAllProducts();
            return PartialView("_ProductList", products); 
        }

        [HttpPost]
        public IActionResult AddProduct(string name, decimal price)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors as JSON
            }

            
                var newProduct = new Product { Name = name, Price = price };
                _productService.AddProduct(newProduct);
            
            return PartialView("_ProductList", _productService.GetAllProducts());
        }
    }
}
