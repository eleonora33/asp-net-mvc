

using BurgerAppRefactored.ViewModels.BurgerViewModels;

namespace BurgerAppRefactored.Services.Interfaces
{
    public interface IBurgerService
    {
        List<BurgerOptionsViewModel>GetBurgersForDropdown();
    }
}
