using ElectronicShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ElectronicShop.Controllers
{
    
    public class CustomerController : Controller
    {
        public ElectronicContext context { get; set; }

        public CustomerController(ElectronicContext ctx)
        {
            context = ctx;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Customer model)
        {
           Customer customer = context.Customers.FirstOrDefault( c=> c.Email == model.Email && c.Password==model.Password);
           if(customer != null)
            {
                HttpContext.Session.SetString("userEmail", model.Email);
                return View("Profile",customer);
            }
            return View();
        }

        public IActionResult Register()
        {
            ViewBag.msg = "";
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer model)
        {
            var cum = context.Customers.FirstOrDefault(c => c.Email.Equals(model.Email));

            if(cum == null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        context.Customers.Add(model);
                        context.SaveChanges();
                        return View("login");
                    }
                    catch (Exception ex)
                    {
                        return View();
                    }
                }
                else
                {
                        ViewBag.msg = "";
                }
            }
            if (cum != null)
            {
                ViewBag.msg = "this email is already exist";
            }
            return View();

        }
        public IActionResult Profile(Customer model)
        {
            if(HttpContext.Session.GetString("userEmail") != null)
            {
                return View("Profile", model);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("userEmail") != null)
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetString("userEmail") != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ChangePassword(string newPass)
        {
            string? usrEmail = HttpContext.Session.GetString("userEmail");
            Customer cs = context.Customers.FirstOrDefault(c => c.Email.Equals(usrEmail));
            cs.Password = newPass;
            context.Customers.Update(cs);
            context.SaveChanges();
                return View("Profile",cs);
        }
    }
}



