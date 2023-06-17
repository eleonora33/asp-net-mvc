using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Extensions
{
    public static class MapperExtenisons
    {
        public static PizzaViewModel MapPizzaToPizzaViewModel(this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                PizzaSize = pizza.PizzaSize,
                HasExtras = pizza.HasExtras
            };
        }
    }
}
