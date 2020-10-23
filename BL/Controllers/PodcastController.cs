using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.Repositories;
using DAL;
using System.ComponentModel;

namespace BL.Controllers
{
    public class PodcastController
    {
        IPodcastRepository<Podcast> podcastRepository;
        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }
        public void CreatePodcastObject ( string url, string interval, string category, string objectType) //objectType = Category?
        {
            Podcast newPodcast = null;
            if(objectType.Equals("Podcast"))
            {
                newPodcast = new Podcast(url, interval, category);
            }
            podcastRepository.Create(newPodcast);
        }

        public List<Podcast> RetrieveAllPodcasts()
        {
            return podcastRepository.GetAllPodcasts();
        }

        public string GetPodCastDetailsByName(string name)
        {
            Podcast podcastObj;
            podcastObj = podcastRepository.GetByName(name);
            return podcastObj.Name + " " + podcastObj.Description + " " + podcastObj.Category;
        }
    }
}
