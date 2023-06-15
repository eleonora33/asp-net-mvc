using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    public class OrdersController : Controller
    {
        [Route("ListOrders")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }

            var order = StaticDb.Orders.FirstOrDefault(o => o.Id == id);

            if(order == null)
            {
                return new EmptyResult();
            }

            return View(order);
        }

        public IActionResult JsonData()
        {
            Order order = new Order
            {
                Id = 1,
                Code = "52-a",
                Pizzas = new List<Pizza>
                {
                    new Pizza
                    {
                        Id = 1,
                        IsOnPromotion = false,
                        Name = "Margarita",
                        Price = 10
                    }
                }
            };

            return new JsonResult(order);
        }

        public IActionResult RedirectToHomeController()
        {
            return RedirectToAction("Index","Home");
        }
    }
}
