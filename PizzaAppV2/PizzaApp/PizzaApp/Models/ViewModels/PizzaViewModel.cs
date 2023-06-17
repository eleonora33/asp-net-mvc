using PizzaApp.Models.Enums;

namespace PizzaApp.Models.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public PizzaSizeEnum PizzaSize { get; set; }
        public bool IsHasExtra { get; set; }
       
    }
}
