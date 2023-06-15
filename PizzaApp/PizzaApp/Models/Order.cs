namespace PizzaApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
