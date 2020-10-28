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

        public void CreatePodcastObject(string url, double interval)
        {
            Podcast newPodcast = null;
            {
                newPodcast = new Podcast(url, interval);
            }
            podcastRepository.Create(newPodcast);
        }

        public List<Episode> GetEpisodeList(object podIndex)
        {
            throw new NotImplementedException();
        }
    }
}
