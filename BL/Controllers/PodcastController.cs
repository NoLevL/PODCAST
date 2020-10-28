using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL;
using Models;
using System.ComponentModel;

namespace BL.Controllers
{
    public class PodcastController
    {
        private IPodcastRepository<Podcast> podcastRepository;
        private Validation validator = new Validation();
        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }

        public void CreatePodcastObject ( string url, double interval, string category)
        {
            Podcast newPodcast = null;
            
            {
                newPodcast = new Podcast(url, interval, category); 
            }
            podcastRepository.Create(newPodcast);
        }

        public void CreatePodcastObject(string url, double interval, string category, string name, int totalEpisodes, List<Episode> episodes)
        {
            Podcast newPodcast = null;
            //if(newPodcast != null)
            {
                newPodcast = new Podcast(url, interval, category, name, totalEpisodes, episodes);
            }
            podcastRepository.Create(newPodcast);
        }

        public List<Podcast> RetrieveAllPodcasts()
        {
            return podcastRepository.GetAll();
        }

        public string GetPodCastDetailsByName(string name)
        {
            Podcast podcastObj;
            podcastObj = podcastRepository.GetByIndex(name);
            return podcastObj.TotalEpisodes + " " + podcastObj.Name + " " + podcastObj.Interval + " " + podcastObj.Category;
        }

        public string GetPodcastUrl(int index)
        {
            DataManager dataManager = new DataManager();
            Podcast podcastObj;
            podcastObj = dataManager.listOfPodcasts[index];
            string url = podcastObj.Url;
                return url;
        }

        public string GetPodcastCategory(int index)
        {
            DataManager dataManager = new DataManager();
            Podcast podcastObj;
            podcastObj = dataManager.listOfPodcasts[index];
            string category = podcastObj.Category;
            return category;
        }

        public double GetPodcastInterval(int index)
        {
            DataManager dataManager = new DataManager();
            Podcast podcastObj;
            podcastObj = dataManager.listOfPodcasts[index];
            double interval = podcastObj.Interval;
            return interval;
        }

        public void CreatePodcastObject(string url, double interval)
        {
            Podcast newPodcast = null;
            {
                newPodcast = new Podcast(url, interval);
            }
            podcastRepository.Create(newPodcast);
        }

        public List<Episode> GetEpisodeList(int podIndex)
        {
            DataManager dataManager = new DataManager();
            List<Episode> listOfEpisodes;
            Podcast podcast = dataManager.listOfPodcasts[podIndex];
            listOfEpisodes = podcast.EpisodeList;
            return listOfEpisodes;
        }
    }
}
