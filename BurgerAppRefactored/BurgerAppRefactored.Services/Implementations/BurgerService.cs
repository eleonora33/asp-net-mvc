using BurgerAppRefactored.DataAccess;
using BurgerAppRefactored.DataAccess.Implementations;
using BurgerAppRefactored.Domain.Models;
using BurgerAppRefactored.Mappers;
using BurgerAppRefactored.Services.Interfaces;
using BurgerAppRefactored.ViewModels.BurgerViewModels;
using System.Collections.Generic;

namespace BurgerAppRefactored.Services.Implementations
{
    public class BurgerService : IBurgerService
    {
        private IRepository<Burger> _burgerRepository;

        public BurgerService(IRepository<Burger> burgerRepository)
        {
            _burgerRepository = burgerRepository;
        }
        public List<BurgerOptionsViewModel> GetBurgersForDropdown()
        {
            List<Burger> burgerDb = _burgerRepository.GetAll();

            List<BurgerOptionsViewModel> burgerOptionsViewModels = new List<BurgerOptionsViewModel>();
            foreach(var burger in burgerDb)
            {
                var burgerOptionsViewModel = BurgerMapper.ToBurgerOptionsViewModel(burger);
                burgerOptionsViewModels.Add(burgerOptionsViewModel);
            }

            return burgerOptionsViewModels;
        }
    }
}
