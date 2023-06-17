using Microsoft.AspNetCore.Mvc;
using PizzaApp.Extensions;
using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> pizzaFromDb = StaticDb.Pizzas;

            List<PizzaViewModel> pizzaViewModelList = pizzaFromDb.Select(x => x.MapPizzaToPizzaViewModel())
            .ToList();

            return View(pizzaViewModelList);
        }

        public IActionResult GetAllPizzas()
        {
            List<Pizza> pizzas = StaticDb.Pizzas;
            return View(pizzas);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }
            
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if(pizza == null)
            {
                return new EmptyResult();
            }

            PizzaViewModel pizzaViewModel = new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                PizzaSize = pizza.PizzaSize,
                HasExtras = pizza.HasExtras
            };

            if(pizzaViewModel.HasExtras)
            {
                pizzaViewModel.Price += 10;
            }

            return View(pizzaViewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
