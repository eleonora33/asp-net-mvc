using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Models.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                UserFullName = $"{user.FirstName} {user.LastName}",
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
