using BurgerAppRefactored.Domain.Models;

namespace BurgerAppRefactored.DataAccess.Implementations
{
    public class BurgerRepository : IRepository<Burger>
    {
        // Use this context instead of static db. This is the actual database context from sql server
        private readonly BurgerAppDbContext _dbContext;

        public BurgerRepository(BurgerAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteById(int id)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(b => b.Id == id);
            if (burger == null) 
            {
                throw new Exception($"Burgers with id {id} was not found!");
            }

            StaticDb.Burgers.Remove(burger); 
        }

        public List<Burger> GetAll()
        {
            return StaticDb.Burgers.ToList();
            //return _dbContext.Burgers.ToList();
        }

        public Burger GetById(int id)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(b => b.Id == id);
            if (burger == null)
            {
                throw new Exception($"Burgers with id {id} was not found!");
            }

           return burger;
        }

        public int Insert(Burger entity)
        {
            entity.Id = StaticDb.Burgers.Count() + 1;
            StaticDb.Burgers.Add(entity);
            return entity.Id;
        }

        public void Update(Burger entity)
        {
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x  => x.Id == entity.Id);
            if(burgerDb == null)
            {
                throw new Exception($"Burgers with id {entity.Id} was not found!");
            }

            int index = StaticDb.Burgers.FindIndex(x  => x.Id == entity.Id);

            StaticDb.Burgers[index] = entity;
        }
    }
}
