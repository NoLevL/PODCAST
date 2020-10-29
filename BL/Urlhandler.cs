using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PodcastApp
{
    public class Urlhandler
    {
        private XDocument urlDocument = new XDocument();
        private string podTitleName;

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
