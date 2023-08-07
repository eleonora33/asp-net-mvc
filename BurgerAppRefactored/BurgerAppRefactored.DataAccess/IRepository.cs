using System;
using System.Collections.Generic;
namespace BurgerAppRefactored.DataAccess
{
    public interface IRepository<T>
    {
        //CRUD method
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Update(T entity);
        void DeleteById(int id);
    }
}
