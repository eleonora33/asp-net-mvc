using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;
using PizzaApp.Models.Domain;
using PizzaApp.Models.Mappers;
using PizzaApp.Models.ViewModels;
using System.Diagnostics;

namespace PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
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
        
        public IActionResult SeeUSers()
        {
            List<User> users = StaticDb.Users;
            List<string> userFullName = users.Select(user => $"{user.FirstName} {user.LastName}").ToList();  

            return View(userFullName);

        }
    }
}