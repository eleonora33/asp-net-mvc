using BurgerAppRefactored.Domain.Models;
using BurgerAppRefactored.ViewModels.BurgerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.Mappers
{
    public static class BurgerMapper
    {
        public static BurgerOptionsViewModel ToBurgerOptionsViewModel(Burger burger)
        {
            return new BurgerOptionsViewModel
            {
                BurgerName = burger.Name,
                Id = burger.Id,
            };
        }
    }
}
