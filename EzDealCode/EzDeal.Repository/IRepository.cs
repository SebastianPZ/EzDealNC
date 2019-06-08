using System.Collections.Generic;

namespace EzDeal.Repository
{
    public interface IRepository<T>
    {
         void Save(T entity);
         void Update(T entity);
         void Delete(T entity);
         List<T> FindAll();
         T FindById(int id);

    }
}