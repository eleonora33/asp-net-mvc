using BurgerShopApp.Models.Domain;

namespace BurgerShopApp
{
    public static class StaticDb
    {
        public static List<Burger> Burgers = new List<Burger>
        {
            new Burger()
            {
                Id = 1,
                Name = "Hamburger classic",
                HasFries = true,
                IsVegan = false,
                IsVegetarian = false,
                Price = 250,
            },
            new Burger()
            {
                Id=2,
                Name = "Tomato",
                HasFries = false,
                IsVegan = true,
                IsVegetarian = true,
                Price = 200
            }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                BurgerId = 1,
                Burger = Burgers.FirstOrDefault(x => x.Id == 1),
                Address = "Ezerci 41-1 A",
                FullName = "Eleonora Todorovska",
                IsDelivered = false,
                Location = "Karpos"
            },
            new Order()
            {
                Id = 2,
                BurgerId = 2,
                Burger = Burgers.FirstOrDefault(x => x.Id == 2),
                Address = "Preseka 4-9 B",
                FullName = "Kalina Gjorjieva",
                IsDelivered = true,
                Location = "Centar"
            }
        };        
    }
}
