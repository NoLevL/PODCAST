using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            if (PodcastFileExists())
            {
                podcastList = GetAll();
            }
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

        private bool PodcastFileExists()
        {
            string file = @"Podcasts.xml";
            bool fileExists = File.Exists(file);
            return fileExists;
        }





    }
}
