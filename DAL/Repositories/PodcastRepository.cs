using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.Repositories
{
    class PodcastRepository : IPodcastRepository<Podcast>
    {
        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public List<Podcast> ReturnPodcasts()
        {
            throw new NotImplementedException();
        }
    }
}
