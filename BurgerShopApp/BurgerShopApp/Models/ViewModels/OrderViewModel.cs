using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BurgerShopApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        [Display(Name = "Burger Name")]
        public string BurgerName { get; set; }

        [Display(Name = "Burger Id")]
        public int BurgerId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Is order delivered")]
        public bool IsDelivered { get; set; }
    }
}
