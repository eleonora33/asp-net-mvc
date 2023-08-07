using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.ViewModels.OrderViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public double Price { get; set; }
        public bool IsDelivered { get; set; }
        public List<string> BurgerNames { get; set; }
    }
}
