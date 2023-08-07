using BurgerAppRefactored.Domain.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace BurgerAppRefactored.Domain.Models
{
    public class Order : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public string Location { get; set; }
        public List<BurgerOrder> BurgerOrders { get; set;}
    }
}
