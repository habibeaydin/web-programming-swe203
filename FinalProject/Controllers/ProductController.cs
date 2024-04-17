using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        public ProductController(AppDbContext context)
        {
            _productRepository = new ProductRepository();

            _context = context;

            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product() {  Name = "Pencil", Price = 18, Stock = 100 });
                _context.Products.Add(new Product() { Name = "Notebook", Price = 20, Stock = 200 });
                _context.Products.Add(new Product() {  Name = "Eraser", Price = 5, Stock = 80 });
                _context.SaveChanges();
            }
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var products = _context.Products.Find(id);
            _context.Products.Remove(products);
            _context.SaveChanges();
            TempData["status"] = "The product has been successfully deleted!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            TempData["status"] = "The product has been successfully added!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct)
        {
            _context.Products.Update(updateProduct);
            _context.SaveChanges();

            TempData["status"] = "The product has been successfully updated!";

            return RedirectToAction("Index");
        }
    }
}
