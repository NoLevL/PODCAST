using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPodcastRepository<T>
    {
        List<T> SavedPodcastList();
        T GetByName(string name);
        List<T> GetAllPodcasts();
    }
}
