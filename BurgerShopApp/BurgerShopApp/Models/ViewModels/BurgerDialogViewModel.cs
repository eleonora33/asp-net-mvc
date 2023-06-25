using System.ComponentModel.DataAnnotations;

namespace BurgerShopApp.Models.ViewModels 
{
    public class BurgerDialogViewModel
    {
        [Display(Name = "Burger ID")]
        public int BurgerId { get; set; }

        [Display(Name = "Burger name")]
        public string? BurgerName { get; set; }

        [Display(Name = "The price of burger is:")]
        public double Price { get; set; }

        [Display(Name = "Vegetarian burger")]
        public bool IsVegetarian { get; set; }

        [Display(Name = "Vegan burger")]
        public bool IsVegan { get; set; }

        [Display(Name = "With fries yes or no")]
        public bool HasFries { get; set; }
        public int Id { get; set; }
    }
}
