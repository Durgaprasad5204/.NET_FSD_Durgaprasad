using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
     public static List<Product> products = new List<Product>
        {
            new Product() { Id = 1, Name = "Laptop", Price = 99999.99, Category = "Electronics" },
            new Product() { Id = 2, Name = "Smartphone", Price = 49999.99, Category = "Electronics" },
            new Product() { Id = 3, Name = "Table", Price = 4999.99, Category = "Furniture" },
            new Product() { Id = 4, Name = "Chair", Price = 999.99, Category = "Furniture" },
            new Product() { Id = 5, Name = "Headphones", Price = 1499.99, Category = "Electronics" }
        };

        //List of all products
        public IActionResult Index()
        {
            return View(products);
        }

        // Details of a specific product
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            products.Add(obj);
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            var existProduct = products.FirstOrDefault(p => p.Id == obj.Id);
            existProduct.Name = obj.Name;
            existProduct.Price = obj.Price;
            existProduct.Category = obj.Category;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product proObj = products.FirstOrDefault(p => p.Id == id);
            return View(proObj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Product proObj = products.FirstOrDefault(p => p.Id == id);
            products.Remove(proObj);
            return RedirectToAction("Index");
        }

    }
}
