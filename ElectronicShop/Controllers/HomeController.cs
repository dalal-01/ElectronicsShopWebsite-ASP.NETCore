using ElectronicShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace ElectronicShop.Controllers
{
    public class HomeController : Controller
    {
        private ElectronicContext context { get; set; }

        public HomeController(ElectronicContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var pros = context.Products.ToList();

            return View(pros);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}