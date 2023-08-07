using BurgerAppRefactored.ViewModels.OrderViewModels;

namespace BurgerAppRefactored.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderDetailsViewModel>GetAllOrders();
        OrderDetailsViewModel GetOrderById(int id);
        void CreateOrder(OrderDialogViewModel orderDialogViewModel);
        void AddBurgerToOrder(AddBurgerToOrderViewModel addBurgerToOrderViewModel);
        void DeleteOrder(int orderId);
    }
}
