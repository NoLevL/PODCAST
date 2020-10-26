﻿using System;
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
        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }

        public void CreatePodcastObject ( string url, string interval, string category, string name, int totalEpisodes, List<Episode> episodeList, string objectType) //objectType = Category?
        {
            Podcast newPodcast = null;
            if(objectType.Equals("Podcast"))
            {
                newPodcast = new Podcast(url, interval, category, name, totalEpisodes, episodeList);
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

        public static Task<Podcast> CreatePodcastObject(string text1, string text2, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public List<Episode> GetEpisodeList(object podIndex)
        {
            throw new NotImplementedException();
        }

        
    }
}
