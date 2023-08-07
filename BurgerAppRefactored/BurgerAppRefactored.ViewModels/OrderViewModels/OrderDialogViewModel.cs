using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.ViewModels.OrderViewModels
{
    public class OrderDialogViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Is order delivered")]
        public bool IsDelivered { get; set; }

        [Display(Name = "Store location")]
        public string Location { get; set; }

        [Display(Name = "Person full name")]

        public string FullName { get; set; }

        [Display(Name = "Burger name")]
        public string Name { get; set; }

        [Display(Name = "Burger id")]
        public int BurgerId { get; set; }
    }
}
