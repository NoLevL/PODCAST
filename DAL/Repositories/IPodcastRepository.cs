using System.Collections.Generic;
using Models;

namespace DAL.Repositories
{
    public interface IPodcastRepository<T> : IRepository<T> where T : Podcast
    {
        //A method for PodcastRepository
        int GetIndex(string name);
    }
}
