using PizzaApp.Models.Enums;

namespace PizzaApp.Views.ViewsModel
{
    public class PizzaViewModel
    {
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int Price { get; set; }
        public PizzaSizeEnum PizzaSizeEnum { get; set; }
    }
}
