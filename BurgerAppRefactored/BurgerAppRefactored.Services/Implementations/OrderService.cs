using BurgerAppRefactored.DataAccess;
using BurgerAppRefactored.DataAccess.Implementations;
using BurgerAppRefactored.Domain.Models;
using BurgerAppRefactored.Mappers;
using BurgerAppRefactored.Services.Interfaces;
using BurgerAppRefactored.ViewModels.OrderViewModels;

namespace BurgerAppRefactored.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Burger> _burgerRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Burger> burgerRepository)
        {
            _orderRepository = orderRepository;
            _burgerRepository = burgerRepository;
        }
        public List<OrderDetailsViewModel> GetAllOrders()
        {
            List<Order> orders = _orderRepository.GetAll();

            List<OrderDetailsViewModel> orderDetailsViewModels = new List<OrderDetailsViewModel>();
            foreach (var order in orders)
            {
                OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(order);
                orderDetailsViewModels.Add(orderDetailsViewModel);
            }

            return orderDetailsViewModels;
        }

        public OrderDetailsViewModel GetOrderById(int id)
        {
            //get the order from repository who will get it from database
            Order orderDb = _orderRepository.GetById(id);

            //validation
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }

            //Mapping the domain to view model
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);
            return orderDetailsViewModel;
        }

        public void CreateOrder(OrderDialogViewModel orderDialogViewModel)
        {
            //validation
            if (orderDialogViewModel == null)
            {
                throw new Exception("Model cannot be null");
            }

            Burger burger = _burgerRepository.GetById(orderDialogViewModel.BurgerId);
            if (burger == null)
            {
                throw new Exception($"Burgers with id {orderDialogViewModel.BurgerId} was not found");
            }

            //mapping
            Order newOrder = OrderMapper.ToOrder(orderDialogViewModel);
            newOrder.BurgerOrders = burger.BurgerOrders;

            //send it to the database
            int newOrderId = _orderRepository.Insert(newOrder);
            if (newOrderId <= 0)
            {
                throw new Exception("An error occurred while adding the new order");
            }
        }

        public void AddBurgerToOrder(AddBurgerToOrderViewModel addBurgerToOrderViewModel)
        {
            Order orderDb = _orderRepository.GetById(addBurgerToOrderViewModel.OrderId);
            if(orderDb == null)
            {
                throw new Exception($"Orders with id {addBurgerToOrderViewModel.OrderId} was not found");
            }

            Burger burgerDb = _burgerRepository.GetById(addBurgerToOrderViewModel.BurgerId);
            if(burgerDb == null)
            {
                throw new Exception($"Burgers with id {addBurgerToOrderViewModel.BurgerId} was not found");
            }

            if(addBurgerToOrderViewModel.Quantity <= 0 || addBurgerToOrderViewModel.Price <= 0)
            {
                throw new Exception("The price and the quantity must be greater than zero!");
            }

            orderDb.BurgerOrders.Add(new BurgerOrder()
            {
                Id = orderDb.BurgerOrders.Count() + 1,
                OrderId = orderDb.Id,
                Burger = burgerDb,
                BurgerId = burgerDb.Id,
                Quantity = addBurgerToOrderViewModel.Quantity,
                Price = addBurgerToOrderViewModel.Price,
                Order = orderDb,
            });

            _orderRepository.Update(orderDb);
        }

        public void DeleteOrder(int orderId)
        {
            Order orderDb = _orderRepository.GetById(orderId);
            if(orderDb == null)
            {
                throw new Exception($"Orders with id {orderId} was not found");
            }

            _orderRepository.DeleteById(orderId);
        }    
    }
}
