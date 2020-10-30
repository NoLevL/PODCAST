using Models;

namespace DAL.Repositories
{
    public interface ICategoryRepository<T> : IRepository<T> where T : Category
    {
        
    }
}
