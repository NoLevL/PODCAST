using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PodcastApp
{
    public class Urlhandler : Feed
    {
        private XDocument urlDocument = new XDocument();
        private string podTitleName;
        private string datePublished;

        public override string GetDateInfo(string url, Episode episode)
        {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            
            List<Episode> episodeList = new List<Episode>();
            
            foreach (SyndicationItem item in feed.Items)
            {
                if (item.Title.Text.Equals(episode.EpisodeName))
                {
                    DateTimeOffset date = item.PublishDate;
                    datePublished = date.ToString();
                }
            }
            return datePublished;

        }
        public bool DoesUrlExist(string url)
        {
            try
            {
                urlDocument = XDocument.Load(url);
                try
                {
                    var totalEpi = GetTotalEpisodes(url);
                    if (totalEpi > 0)
                    {
                        return true;
                    }
                }catch (Exception) { }
            }catch (Exception) { }
            return false;
        }

        public int GetTotalEpisodes(string url)
        {
            int totalEpisodes = 0;
            urlDocument = XDocument.Load(url);
            var items = (from x in urlDocument.Descendants("item")
                         select new { 
                             title = x.Element("title") 
                         });

            if (items != null)
            {
                foreach (var item in items)
                {
                    totalEpisodes++;
                }
            }
            return totalEpisodes;
        }

        public string GetUrlName(string url)
        {
            urlDocument = XDocument.Load(url);
            var items = (from x in urlDocument.Descendants("image")
                         select new { 
                             title = x.Element("title").Value 
                         });

            if ( items!= null)
            {
                foreach (var item in items)
                {
                    podTitleName = item.title;
                }
            }
            return podTitleName;
        }

        public List<Episode> GetEpisodes (string url)
        {
            List<Episode> episodeList = new List<Episode>();
            
            
                urlDocument = XDocument.Load(url);
                episodeList = (from x in urlDocument.Descendants("item")
                               select new Episode
                               {
                                   EpisodeName = x.Element("title").Value,
                                   EpisodeDescription = x.Element("description").Value
                               }).ToList();
            
            return episodeList;
        }




    }
}
