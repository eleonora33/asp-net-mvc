using BurgerAppRefactored.DataAccess;
using BurgerAppRefactored.DataAccess.Implementations;
using BurgerAppRefactored.Domain.Models;
using BurgerAppRefactored.Services.Implementations;
using BurgerAppRefactored.Services.Interfaces;
using BurgerAppRefactored.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerAppRefactored.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBurgerService _burgerService;

        public OrderController(IOrderService orderService, IBurgerService burgerService)
        {
            _orderService = orderService;
            _burgerService = burgerService;
        }
        public IActionResult Index()
        {
            List<OrderDetailsViewModel> viewModels = _orderService.GetAllOrders();

            return View(viewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("Bed request");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderById(id.Value);
                return View(orderDetailsViewModel);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;

                return View("General error");                   
            };         
        }

        public IActionResult CreateOrder() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrderPost(OrderDialogViewModel orderDialogViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderDialogViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }
        }

        public IActionResult AddBurger(int id) 
        {
            ViewBag.Burgers = _burgerService.GetBurgersForDropdown();
            AddBurgerToOrderViewModel addBurgerToOrderViewModel = new AddBurgerToOrderViewModel();
            addBurgerToOrderViewModel.BurgerId = id;
            return View(addBurgerToOrderViewModel);
        }

        [HttpPost]
        public IActionResult AddBurgerPost(AddBurgerToOrderViewModel addBurgerToOrderViewModel)
        {
            try
            {
                _orderService.AddBurgerToOrder(addBurgerToOrderViewModel);
                return RedirectToAction("Details", new {id = addBurgerToOrderViewModel.OrderId});
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("General error");
            }
        }

        public IActionResult DeleteOrder(int? id)
        {
            if(id == null)
            {
                return View("Bed Request");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderById(id.Value);
                return View(orderDetailsViewModel);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("General error");
            }

        }

        public IActionResult ConfirmDelete(int? id)
        {
            if(id == null)
            {
                return View("Bed request");
            }

            try
            {
                _orderService.DeleteOrder(id.Value);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("General error");
            }
        }
    }
}
