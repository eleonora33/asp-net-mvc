using BurgerAppRefactored.Domain.Models;
using BurgerAppRefactored.ViewModels.OrderViewModels;

namespace BurgerAppRefactored.Mappers
{
    public static class OrderMapper
    {
        public static OrderDetailsViewModel ToOrderDetailsViewModel(Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                IsDelivered = order.IsDelivered,
                Price = order.BurgerOrders.Sum(o => o.Price),
                BurgerNames = order.BurgerOrders.Select(o => o.Burger.Name).ToList()
            };
        }

        public static Order ToOrder(OrderDialogViewModel orderDialogViewModel)
        {
            return new Order
            {
                Id = orderDialogViewModel.Id,
                FullName = orderDialogViewModel.FullName,
                Location = orderDialogViewModel.Location,
                IsDelivered = orderDialogViewModel.IsDelivered,
                BurgerOrders = new List<BurgerOrder>()
            };
        }
    }
}