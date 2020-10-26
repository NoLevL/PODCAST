using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BL
{
    class Urlinfo
    {
        private XDocument urlDocument = new XDocument();
        private string podcastTitleName;

        public bool DoesUrlExist(string url)
        {
            try
            {
                urlDocument = XDocument.Load(url);
                try
                {
                    var totalEp = GetTotalEpisodes(url);
                    if (totalEp > 0)
                    {
                        return true;
                    }
                } catch (Exception) { }
            }
            catch (Exception) { }
            return false;
        }

        public int GetTotalEpisodes(string url)
        {
            int totalEpisodes = 0;
            urlDocument = XDocument.Load(url);
            var items = (from x in urlDocument.Descendants("item")
                         select new { title = x.Element("title") });

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
                         select new
                         {
                             title = x.Element("title").Value
                         });

            if ( items != null)
            {
                foreach (var item in items)
                {
                    podcastTitleName = item.title;
                }
            }
            return podcastTitleName;
        }


        public async Task <List<Episode>> GetEpisodes (string url)
        {
            List<Episode> episodeList = new List<Episode>();
            await Task.Run(() =>
            {
                urlDocument = XDocument.Load(url);
                episodeList = (from x in urlDocument.Descendants("item")
                               select new Episode
                               {
                                   EpisodeName = x.Element("title").Value,
                                   EpisodeDescription = x.Element("description").Value
                               }).ToList();
            });

            return episodeList;
        }
    }
}
