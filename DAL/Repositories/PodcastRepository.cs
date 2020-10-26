using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;



namespace DAL.Repositories
{
    public class PodcastRepository : IPodcastRepository<Podcast>
    {
        DataManager dataManager;
        List<Podcast> podcastList;
        public PodcastRepository()
        {
            podcastList = new List<Podcast>();
            dataManager = new DataManager();
        }

        public void Create(Podcast entity)
        {
            podcastList.Add(entity);
            SaveChanges();
        }

        public void Delete(int index)
        {
            podcastList.RemoveAt(index);
            SaveChanges();
        }

        public List<Podcast> GetAll()
        {
            List<Podcast> podcastListToBeReturned = new List<Podcast>();
            podcastListToBeReturned = dataManager.ReturnPodcasts();
            return podcastListToBeReturned;
            throw new NotImplementedException();
        }


        public Podcast GetByIndex(string name)
        {
            throw new NotImplementedException();
        }

        public Podcast GetByName(string name)
        {
            return GetAll().FirstOrDefault(p => p.Name.Equals(name));
        }

        public List<Podcast> ReturnPodcasts()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            dataManager.SavePodcastList(podcastList);
        }

        public List<Podcast> SavedPodcastList()
        {
            throw new NotImplementedException();
        }

        public void Update(int index, Podcast newEntity)
        {
            if (index >= 0)
            {
                podcastList[index] = newEntity;
            }
            SaveChanges();
        }


    }
}
