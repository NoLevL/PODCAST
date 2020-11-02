using System.Collections.Generic;
using DAL.Repositories;
using DAL;
using Models;

namespace BL.Controllers
{
    public class PodcastController
    {
        private IPodcastRepository<Podcast> podcastRepository;
        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }

        public void CreatePodcastObject(string url, double interval, string category, string name, int totalEpisodes, List<Episode> episodes)
        {
            Podcast newPodcast = new Podcast(url, interval, category, name, totalEpisodes, episodes);
            
            podcastRepository.Create(newPodcast);
        }

        //Returns all saved podcasts
        public List<Podcast> RetrieveAllPodcasts()
        {
            return podcastRepository.GetAll();
        }

        //Returns the url from a saved podcast
        public string GetPodcastUrl(int index)
        {
            Podcast podcastObj = podcastRepository.GetAll()[index];
            string url = podcastObj.Url;
            return url;
        }

        //Returns the category of a saved podcast
        public string GetPodcastCategory(int index)
        {
            Podcast podcastObj = podcastRepository.GetAll()[index];
            string category = podcastObj.Category;
            return category;
        }

        //Returns the string value of interval of a saved podcast
        public string GetPodcastInterval(int index)
        {
            Podcast podcastObj = podcastRepository.GetAll()[index];
            string interval = podcastObj.Interval.ToString();
            return interval + " min";
        }

        //Returns a list of Episode from a saved podcast
        public List<Episode> GetEpisodeList(int podIndex)
        {
            DataManager dataManager = new DataManager();
            List<Episode> listOfEpisodes;
            Podcast podcast = podcastRepository.GetAll()[podIndex];

            listOfEpisodes = podcast.EpisodeList;
            
            return listOfEpisodes;
        }

        //Deletes a podcast based on an index
        public void DeletePodcast(int index)
        {
            podcastRepository.Delete(index);
        }

        //Deletes a podcasts based on a category 
        public void DeletePodcast(string category)
        {
            podcastRepository.Delete(category);
        }

        
        public void UpdatePodcastName(int index, string name)
        {
            Podcast podcastObj = podcastRepository.GetAll()[index];
            string newName = name;
            podcastObj.Name = newName;
            podcastRepository.Update(index, podcastObj);
        }


        public void UpdatePodcast(int index, string cat, double interval)
        {
            Podcast podcastObj = podcastRepository.GetAll()[index];
            podcastObj.Category = cat;
            podcastObj.Interval = interval;
            podcastRepository.Update(index, podcastObj);
        }
    }
}
