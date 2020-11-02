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

        public void Delete(string category)
        {
            List<Podcast> list = GetAll();
            foreach (var item in list.ToList())
            {
                if (item.Category.Equals(category)) 
                {
                    list.Remove(item);
                }
            }
            dataManager.SavePodcastList(list);
        }

        public List<Podcast> GetAll()
        {
            List<Podcast> podcastListToBeReturned = new List<Podcast>();
            podcastListToBeReturned = dataManager.ReturnPodcasts();
            return podcastListToBeReturned;
        }

        //Finds the index from the saved podcasts based on it's name
        public int GetIndex(string name)
        {
            return GetAll().FindIndex(p => p.Name.Equals(name));
        }

        public void SaveChanges()
        {
            dataManager.SavePodcastList(podcastList);
        }

        public void SaveChanges(List<Podcast> podList)
        {
            dataManager.SavePodcastList(podList);
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
