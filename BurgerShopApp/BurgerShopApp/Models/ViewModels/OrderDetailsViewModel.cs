namespace BurgerShopApp.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public string BurgerName { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
    }
}
