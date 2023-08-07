using BurgerAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.DataAccess.EFImplementations
{
    public class BurgerEFRepository : IRepository<Burger>
    {
        private BurgerAppDbContext _burgerAppDbContext;

        public BurgerEFRepository(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }

        public void DeleteById(int id)
        {
            Burger burgerDb = _burgerAppDbContext.Burgers.FirstOrDefault(x => x.Id == id);
            if (burgerDb == null)
            {
                throw new Exception($"Burgers with id {id} was not found");
            }

            _burgerAppDbContext.Burgers.Remove(burgerDb);
            _burgerAppDbContext.SaveChanges();
        }

        public List<Burger> GetAll()
        {
            return _burgerAppDbContext.Burgers.ToList();
        }

        public Burger GetById(int id)
        {
            return _burgerAppDbContext.Burgers.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Burger entity)
        {
            _burgerAppDbContext.Burgers.Add(entity);
            _burgerAppDbContext.SaveChanges();

            return entity.Id;
        }

        public void Update(Burger entity)
        {
            _burgerAppDbContext.Burgers.Update(entity);
            _burgerAppDbContext.SaveChanges();
        }
    }
}
