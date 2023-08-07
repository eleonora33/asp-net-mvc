using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.ViewModels.OrderViewModels
{
    public class AddBurgerToOrderViewModel
    {
        public int OrderId { get; set; }

        [Display(Name ="Burger")]
        public int BurgerId { get; set; }

        [Display(Name ="Burger name")]
        public string BurgerName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }   
    }
}
