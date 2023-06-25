using BurgerShopApp.Models.Domain;
using BurgerShopApp.Models.Mappers;
using BurgerShopApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShopApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View(StaticDb.Orders);
        }

        public IActionResult GetAllOrders()
        {
            List<Order> ordersDb = StaticDb.Orders;

            List<OrderListViewModel> orderListViewModels =
                ordersDb.Select(x => OrderMapper.OrderToOrderListViewModel(x)).ToList();

            return View(orderListViewModels);

        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("GeneralError", new GeneralErrorViewModel
                {
                    ErrorMessage = "You must provide an id to view details!"
                });
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            ViewData["Title"] = "Order details";

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
            return View(orderDetailsViewModel);
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return View("GeneralError", new GeneralErrorViewModel
                {
                    ErrorMessage = "Id is invalid"
                });
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
            return View(orderDetailsViewModel);
        }

        public IActionResult ConfirmDelete(int id)
        {
            if (id <= 0)
            {
                return View("GeneralError", new GeneralErrorViewModel
                {
                    ErrorMessage = "Id is invalid"
                });
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.Remove(orderDb);
            return RedirectToAction("GetAllOrders");
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            OrderViewModel orderViewModel = new OrderViewModel();

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrderPost(OrderViewModel orderViewModel)
        {
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Name == orderViewModel.BurgerName);
            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            Order newOrder = new Order
            {
                Id = StaticDb.Orders.Count + 1,
                Address = orderViewModel.Address,
                Burger = burgerDb,
                FullName = orderViewModel.FullName,
                IsDelivered = orderViewModel.IsDelivered,
                Location = orderViewModel.Location,
                BurgerId = burgerDb.Id,
            };
            StaticDb.Orders.Add(newOrder);

            return RedirectToAction("GetAllOrders");
        }

        public IActionResult EditOrder(int id)
        {
            Order orderForEdit = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderForEdit == null)
            {
                return View("ResourceNotFound");
            }

            OrderViewModel orderViewModel = OrderMapper.OrderToOrderViewModel(orderForEdit);

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult EditOrderPost(OrderViewModel orderViewModel)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.OrderId);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Name == orderViewModel.BurgerName);
            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            orderDb.Address = orderViewModel.Address;
            orderDb.Burger = burgerDb;
            orderDb.BurgerId = burgerDb.Id;
            orderDb.FullName = orderViewModel.FullName;
            orderDb.IsDelivered = orderViewModel.IsDelivered;
            orderDb.Location = orderViewModel.Location;

            return RedirectToAction("GetAllOrders");
        }
    }
}
