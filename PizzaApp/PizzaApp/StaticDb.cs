
using PizzaApp.Models;

namespace PizzaApp
{
    public static class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza()
            {
                Id = 1,
                Name = "Capricciosa",
                Price = 300,
                IsOnPromotion = true
            },
            new Pizza()
            {
                Id = 2,
                Name = "Pepperoni",
                Price = 350,
                IsOnPromotion = false
            }

        };

        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                Code = "40-b",
                Pizzas = new List<Pizza>
                {
                    Pizzas[0]
                }
            },
            new Order()
            {
                Id = 2,
                Code = "45-c",
                Pizzas = new List<Pizza>
                {
                    Pizzas[1]
                },
            },
            new Order()
            {
                Id = 3,
                Code = "48-e",
                Pizzas = new List<Pizza>
                {
                    Pizzas[0],
                    Pizzas[1]
                },
            }
        };
    }
}
