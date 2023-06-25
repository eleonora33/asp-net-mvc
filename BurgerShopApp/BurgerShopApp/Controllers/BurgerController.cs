using BurgerShopApp.Models.Domain;
using BurgerShopApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShopApp.Controllers
{
	public class BurgerController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View(StaticDb.Burgers);
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return RedirectToAction("Error");
			}

			Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

			if (burger == null)
			{
				return View("ResourceNotFound");
			}

			return View(burger);
		}

		public IActionResult GetAllBurgers()
		{
			List<Burger> burgers = StaticDb.Burgers;

			return View(burgers);
		}

		public IActionResult CreateBurger()
		{
			BurgerDialogViewModel viewModel = new BurgerDialogViewModel();

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult CreateBurgerPost(BurgerDialogViewModel burgerDialogViewModel)
		{

			Burger newBurger = new Burger
			{
				Id = StaticDb.Burgers.Count + 1,
				Name = burgerDialogViewModel.BurgerName,
				Price = burgerDialogViewModel.Price,
				IsVegan = burgerDialogViewModel.IsVegan,
				IsVegetarian = burgerDialogViewModel.IsVegetarian,
				HasFries = burgerDialogViewModel.HasFries
			};

			StaticDb.Burgers.Add(newBurger);

			return RedirectToAction("Index");
		}

		public IActionResult EditBurger(int? id)
		{
			if (id == null)
			{
				return View("Error");
			}

			Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

			if (burgerDb == null)
			{
				return RedirectToAction("ResourceNotFound");
			}

			BurgerDialogViewModel burgerDialogViewModel = new BurgerDialogViewModel
			{
				BurgerId = burgerDb.Id,
				BurgerName = burgerDb.Name,
				Id = burgerDb.Id,
				HasFries = burgerDb.HasFries,
				IsVegan = burgerDb.IsVegan,
				IsVegetarian = burgerDb.IsVegetarian,
				Price = burgerDb.Price,
			};

			return View(burgerDialogViewModel);
		}

		[HttpPost]
		public IActionResult EditBurger(BurgerDialogViewModel burgerDialogViewModel)
		{
			if (burgerDialogViewModel == null)
			{
				return View("Error");
			}

			Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerDialogViewModel.Id);

			if (burgerDb == null)
			{
				return RedirectToAction("ResourceNotFound");
			}

			burgerDb.Id = burgerDialogViewModel.Id;
			burgerDb.Name = burgerDialogViewModel.BurgerName;
			burgerDb.IsVegetarian = burgerDialogViewModel.IsVegetarian;
			burgerDb.IsVegan = burgerDialogViewModel.IsVegan;
			burgerDb.HasFries = burgerDialogViewModel.HasFries;
			burgerDb.Price = burgerDialogViewModel.Price;

			return RedirectToAction("Index");
		}

		public IActionResult DeleteBurger(int? id)
		{
			if (id == null)
			{
				return View("Error");
			}

			Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

			if (burgerDb == null)
			{
				return View("ResourceNotFound");
			}

			StaticDb.Burgers.Remove(burgerDb);

			return RedirectToAction("Index");
		}
	}
}
