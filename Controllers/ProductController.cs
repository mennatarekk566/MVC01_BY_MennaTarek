using Microsoft.AspNetCore.Mvc;
using MVC01_BY_MennaTarek.Models;

namespace MVC01_BY_MennaTarek.Controllers
{
    public class ProductController : Controller
    {
        // In-Memory Data (بدل الـ Database)
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 10, Name = "Laptop",   Price = 25000, Description = "Gaming Laptop",   Quantity = 5  },
            new Product { Id = 11, Name = "Mobile",   Price = 12000, Description = "Smart Phone",     Quantity = 10 },
            new Product { Id = 12, Name = "Keyboard", Price = 800,   Description = "Mechanical",      Quantity = 20 },
            new Product { Id = 13, Name = "Mouse",    Price = 400,   Description = "Wireless Mouse",  Quantity = 30 },
            new Product { Id = 14, Name = "Monitor",  Price = 6000,  Description = "27 inch 144Hz",   Quantity = 8  }
        };

        // GET: /Product
        public IActionResult Index()
        {
            return View(_products);
        }

        // GET: /Product/Details/10
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();

            return View(product);
        }

        // GET: /Product/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            product.Id = _products.Count == 0 ? 1 : _products.Max(p => p.Id) + 1;
            _products.Add(product);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Product/Edit/10
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();

            return View(product);
        }

        // POST: /Product/Edit/10
        [HttpPost]
        public IActionResult Edit(int id, Product updated)
        {
            if (id != updated.Id) return BadRequest();
            if (!ModelState.IsValid) return View(updated);

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();

            product.Name = updated.Name;
            product.Price = updated.Price;
            product.Description = updated.Description;
            product.Quantity = updated.Quantity;

            return RedirectToAction(nameof(Index));
        }

        // GET: /Product/Delete/10
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();

            return View(product);
        }

        // POST: /Product/Delete/10
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product is not null)
                _products.Remove(product);

            return RedirectToAction(nameof(Index));
        }
    }
}