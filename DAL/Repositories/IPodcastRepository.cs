using System.Collections.Generic;
using Models;

namespace DAL.Repositories
{
    public interface IPodcastRepository<T> : IRepository<T> where T : Podcast
    {

        int GetIndex(string name);
    }
}
