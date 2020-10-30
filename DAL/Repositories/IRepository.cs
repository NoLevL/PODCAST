using System.Collections.Generic;

namespace DAL
{
    public interface IRepository<T> where T:class
    {
        void Create(T entity);
        void Delete(int index);
        void Delete(string entity);
        void Update(int index, T entity);
        void SaveChanges();
        List<T> GetAll();
    }
}
