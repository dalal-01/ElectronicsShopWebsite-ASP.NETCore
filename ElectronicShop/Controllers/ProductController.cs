using ElectronicShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicShop.Controllers
{
    public class ProductController : Controller
    {
        private ElectronicContext context { get; set; }

        public ProductController(ElectronicContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }

        public IActionResult DeleteProduct(int id)
        {
            string? usrEmail = HttpContext.Session.GetString("userEmail");
            if (HttpContext.Session.GetString("userEmail") != null)
            {
                if(usrEmail == "admin@g.com")
                {
                    var product = context.Products.Find(id);
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
               return RedirectToAction("Index","Home");
        }

        public IActionResult Search(string Key)
        {
                var products = context.Products.Where(p => p.Name.Contains(Key)).ToList();
                return View("index", products);
        }

    }
}

