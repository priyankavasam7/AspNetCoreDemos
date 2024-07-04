using Microsoft.AspNetCore.Mvc;
using AspNetCoreEmpty.Models;
using AspNetCoreEmpty.ViewModels;
namespace AspNetCoreEmpty.Controllers
{
    public class HomeController : Controller
    {
        /*
         * View Data
         * 1. Create Views folder
         * 2. Create a folder with the same name of Controller
         * 3. Add the <actionname> .cshtml file
         * 4. Use ViewData to pass data from controller to view
         * 5. Type cast ViewData if you are passing any value other than string in the value
         */
        public IActionResult Index()
        {
            /* 
             ViewData["Title"] = "Welcome to MVC";
             var customer= new Customer { Id= 1 ,Name="Tina"};
             ViewData["customer"] = customer;
            return View();
            */

            /*
            ViewBag.Title = "Welcome to MVC (ViewBag)";
            var customer = new Customer { Id = 1, Name = "Tina" };
            ViewBag.customer = customer;
            return View();
            */

            /*
            ViewBag.Title = "Welcome to MVC (ViewBagModel)";
            var customer=new Customer { Id = 1 , Name="Tina"};
            return View(customer); // passing the customer object to the view
            */

            var HomeIndexViewModel = new HomeIndexViewModel
            {
                Title = "Welcome to MVC (HomeIndexViewModel)",
                Customer = new Customer { Id = 1, Name = "Tina" },
            };

            return View(HomeIndexViewModel);

        }

        public string Details()
        {
            return "Details";
        }

        public IActionResult Customers()
        {
            List<Customer> customers = new List<Customer>
            {
            new Customer { Id = 1, Name = "Tina" },
            new Customer { Id = 2, Name = "July" },
            new Customer { Id = 3, Name = "August" }
            };
            return View(customers);
        }
    }
}
