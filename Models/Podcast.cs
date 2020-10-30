using System.Collections.Generic;


namespace Models
{
    public class Podcast
    {
        public string Url { get; set; }

        public double Interval { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int TotalEpisodes { get; set; }

        public List<Episode> EpisodeList { get; set; }


        public Podcast(string url, double interval, string category, string name, int totalEpisodes, List<Episode> episodeList)
        {
            Url = url;
            Interval = interval;
            Category = category;
            Name = name;
            TotalEpisodes = totalEpisodes;
            EpisodeList = episodeList;
        }

        public Podcast()
        {

        }
    }
}
