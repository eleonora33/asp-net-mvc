using BurgerShopApp.Models.Domain;
using BurgerShopApp.Models.ViewModels;

namespace BurgerShopApp.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderListViewModel OrderToOrderListViewModel(Order orderDb)
        {
            return new OrderListViewModel
            {
                Id = orderDb.Id,
                FullName = orderDb.FullName,
                BurgerName = orderDb.Burger.Name
            };
        }

        public static OrderDetailsViewModel OrderToOrderDetailsViewModel(Order orderDb)
        {
            return new OrderDetailsViewModel
            {
                Id = orderDb.Id,
                Address = orderDb.Address,
                FullName = orderDb.FullName,
                BurgerName = orderDb.Burger.Name,
                IsDelivered = orderDb.IsDelivered,
                Location = orderDb.Location,
                Price = orderDb.Burger.Price
            };
        }

        public static OrderViewModel OrderToOrderViewModel(Order orderDb)
        {
            return new OrderViewModel
            {
                Address = orderDb.Address,
                BurgerId = orderDb.Burger.Id,
                FullName = orderDb.FullName,
                IsDelivered = orderDb.IsDelivered,
                Location = orderDb.Location,
                OrderId = orderDb.Id,
                BurgerName = orderDb.Burger.Name
            };
        }
    }
}
