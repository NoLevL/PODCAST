using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;

namespace PodcastApp
{
    public class Urlhandler : Date
    {
        private XDocument xDocument = new XDocument();
        
        //Overrides the method of the parent class and returns the string value of the published date of an episode
        public override string GetDateInfo(string url, Episode episode)
        {
            string datePublished = "";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            
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

        //Returns the name of a podcast from a url
        public string GetPodcastName(string url)
        {
            string podcastName = "";
            xDocument = XDocument.Load(url);
            var podcast = (from x in xDocument.Descendants("image")
                         select new { 
                             title = x.Element("title").Value 
                         });

            if ( podcast!= null)
            {
                foreach (var item in podcast)
                {
                    podcastName = item.title;
                }
            }
            return podcastName;
        }

        //Returns a list of Episode of a podcast from a url
        public List<Episode> GetEpisodes (string url)
        {
            List<Episode> episodeList = new List<Episode>();
            xDocument = XDocument.Load(url);
            episodeList = (from x in xDocument.Descendants("item")
                               select new Episode {
                                   EpisodeName = x.Element("title").Value,
                                   EpisodeDescription = x.Element("description").Value
                               }).ToList();
            return episodeList;
        }

    }
}
