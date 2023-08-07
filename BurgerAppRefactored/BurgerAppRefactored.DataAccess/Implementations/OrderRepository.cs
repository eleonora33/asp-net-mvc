using BurgerAppRefactored.Domain.Models;

namespace BurgerAppRefactored.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"Orders with id {id} was not found!");
            }

            StaticDb.Orders.Remove(orderDb);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders.ToList();
        }

        public Order GetById(int id)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"Orders with id {id} was not found!");
            }

            return orderDb;     
        }

        public int Insert(Order entity)
        {
            entity.Id = StaticDb.Orders.Count() + 1;
            StaticDb.Orders.Add(entity);
            return entity.Id;
        }

        public void Update(Order entity)
        {
           Order orderDb = StaticDb.Orders.FirstOrDefault(o => o.Id ==  entity.Id);
            if(orderDb == null)
            {
                throw new Exception($"Orders with id {entity.Id} was not found!");
            }

            int index = StaticDb.Orders.FindIndex(o => o.Id == entity.Id);

            StaticDb.Orders[index] = entity;
        }
    }
}
