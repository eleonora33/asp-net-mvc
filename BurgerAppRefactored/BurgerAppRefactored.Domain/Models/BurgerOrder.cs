using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.Domain.Models
{
    public class BurgerOrder : BaseEntity
    {
        public Burger Burger { get; set; }
        public int BurgerId { get; set; }   
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
