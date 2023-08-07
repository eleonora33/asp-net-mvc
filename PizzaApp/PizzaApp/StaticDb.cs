using PizzaApp.Models.Domain;

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
                IsOnPromotion = true,
                IsHasExtras = true,
            },
            new Pizza()
            {
                Id = 2,
                Name = "Pepperoni",
                Price = 350,
                IsOnPromotion = false,
                IsHasExtras = false,
            },
            new Pizza()
            {
                Id = 2,
                Name = "Pepperoni",
                Price = 200.5,
                IsOnPromotion = false,
                IsHasExtras = false,
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
        public static List<User> Users = new List<User>
        {
            new User()
            {
                Id = 1,
                FirstName = "Eleonora",
                LastName = "Todorovska",
                PhoneNumber = "1234567890",
                Address = "Ezerci 4b"
            },
            new User()
            {
                Id = 2,
                FirstName = "Toso",
                LastName = "Malerot",
                PhoneNumber = "1234567891",
                Address = "Stopanski dvor 10 a"
            }
        };
    }
}
