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
            
            int podcastIndex = podcastRepository.GetIndex(name);
            podcastObj = podcastRepository.GetAll()[podcastIndex];
            return podcastObj.TotalEpisodes + " " + podcastObj.Name + " " + podcastObj.Interval + " " + podcastObj.Category;
        }

        public string GetPodcastUrl(int index)
        {
            Podcast podcastObj = podcastRepository.GetAll()[index];
            string url = podcastObj.Url;
            return url;
        }

        public string GetPodcastCategory(int index)
        {
            Podcast podcastObj = podcastRepository.GetAll()[index];
            string category = podcastObj.Category;
            return category;
        }

        public string GetPodcastInterval(int index)
        {
            Podcast podcastObj = podcastRepository.GetAll()[index];
            string interval = podcastObj.Interval.ToString();
            return interval + " min";
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
            //Console.WriteLine(podcastRepository.GetAll().Count);
            Podcast podcast = podcastRepository.GetAll()[podIndex];

            listOfEpisodes = podcast.EpisodeList;
            
            return listOfEpisodes;
        }

        public void DeletePodcast(int index)
        {
            podcastRepository.Delete(index);
        }

        public void DeletePodcast(string category)
        {
            podcastRepository.Delete(category);
        }
    }
}
