using BurgerAppRefactored.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.DataAccess.EFImplementations
{
    public class OrderEFRepository : IRepository<Order>
    {
        private BurgerAppDbContext _burgerAppDbContext;

        public OrderEFRepository(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }
        public void DeleteById(int id)
        {
            Order orderDb = _burgerAppDbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"Ordet with id {id} was not found");
            }

            _burgerAppDbContext.Orders.Remove(orderDb);
            _burgerAppDbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            var orderDb = _burgerAppDbContext.Orders
                .Include(x => x.BurgerOrders)
                .ThenInclude(x => x.Burger).ToList();       

            return orderDb;
        }

        public Order GetById(int id)
        {
            var orderDb = _burgerAppDbContext.Orders
                 .Include(x => x.BurgerOrders)
                 .ThenInclude(x => x.Burger)
                 .FirstOrDefault(x => x.Id == id);
                 
            if (orderDb == null)
            {
                throw new Exception($"Orders with id {id} was not found!");
            }

            return orderDb;
        }

        public int Insert(Order entity)
        {
            _burgerAppDbContext.Orders.Add(entity);
            _burgerAppDbContext.SaveChanges();

            return entity.Id;
        }

        public void Update(Order entity)
        {
            _burgerAppDbContext.Orders.Update(entity);
            _burgerAppDbContext.SaveChanges();
        }
    }
}
