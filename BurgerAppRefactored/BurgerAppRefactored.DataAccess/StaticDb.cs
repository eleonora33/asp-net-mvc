using BurgerAppRefactored.Domain.Models;

namespace BurgerAppRefactored.DataAccess
{
    public static class StaticDb
    {
        public static List<Burger> Burgers = new List<Burger>
        {
            new Burger()
            {
                Id = 1,
                Name = "VeganMix",
                Price = 240,
                HasFries = true,
                IsVegan = true,
                IsVegetarian = false,
                BurgerOrders = new List<BurgerOrder>
                {

                }
            },

            new Burger()
            {
                Id = 2,
                Name = "Sedmica",
                Price = 170,
                HasFries = true,
                IsVegan = false,
                IsVegetarian = false,
                BurgerOrders = new List<BurgerOrder>
                {

                }
            },

            new Burger()
            {
                Id = 3,
                Name = "Cold Mix",
                Price = 120,
                HasFries = false,
                IsVegan = false,
                IsVegetarian = false,
                BurgerOrders = new List<BurgerOrder>
                {

                }
            },
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                FullName = "Eleonora Todorovska",
                Address = "Karpos",
                IsDelivered = true,
                Location = "Jacomo",
                BurgerOrders = new List<BurgerOrder>
                {
                    new BurgerOrder
                    {
                        Id = 1,
                        Burger = Burgers[0],
                        BurgerId = Burgers[0].Id,
                        OrderId = 1,
                        Price = Burgers[0].Price,
                        Quantity = 1       
                    }
                }
            },

            new Order()
            {
                Id = 2,
                FullName = "Kalina Gj.",
                Address = "Vlae",
                IsDelivered = true,
                Location = "Dominos",
                BurgerOrders = new List<BurgerOrder>
                {
                    new BurgerOrder
                    {
                        Id = 2,
                        Burger = Burgers[1],
                        BurgerId = Burgers[1].Id,
                        OrderId = 2,
                        Price= Burgers[1].Price,
                        Quantity = 2
                    }
                }
            },

            new Order()
            {
                Id = 3,
                FullName = "Marjan Gj.",
                Address = "Gjorce",
                IsDelivered = false,
                Location = "King burger",
                BurgerOrders = new List<BurgerOrder>
                {
                    new BurgerOrder
                    {
                        Id = 3,
                        Burger = Burgers[2],
                        BurgerId = Burgers[2].Id,
                        OrderId = 3,
                        Price = Burgers[2].Price,
                        Quantity = 3
                    }
                }
            },
        };       
    }
}