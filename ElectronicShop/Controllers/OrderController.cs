using ElectronicShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicShop.Controllers
{
    public class OrderController : Controller
    {
        private ElectronicContext context { get; set; }

        public OrderController(ElectronicContext ctx)
        {
            context = ctx;
        }

        public IActionResult Orders()
        {
            var UsrEmail = HttpContext.Session.GetString("userEmail");
            if (UsrEmail != null && HttpContext.Session.GetString("userEmail") != "admin@g.com")
            {
                Customer cs = context.Customers.FirstOrDefault(c => c.Email.Equals(UsrEmail));
                var orders = context.Orders.Where(o => o.CustomerID.Equals(cs.CustomerID)).Include(o => o.products).ToList();
                return View(orders);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddOrder(int id)
        {
            var UsrEmail = HttpContext.Session.GetString("userEmail");
            if (UsrEmail != null)
            {
                Customer cs = context.Customers.FirstOrDefault(c => c.Email.Equals(UsrEmail));
                ViewBag.Pid = id;
                ViewBag.Cid = cs.CustomerID;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddOrder(Order model)
        {
            context.Orders.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index","Product");
        }

        public IActionResult deleteOrder(int id)
        {
            var UsrEmail = HttpContext.Session.GetString("userEmail");
            if (UsrEmail != null)
            {
                var order = context.Orders.Find(id);
                context.Orders.Remove(order);
                context.SaveChanges();

                Customer cs = context.Customers.FirstOrDefault(c => c.Email.Equals(UsrEmail));
                var orders = context.Orders.Where(o => o.CustomerID.Equals(cs.CustomerID)).Include(o => o.products).ToList();
                return View("Orders",orders);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
