namespace Models
{
    public class Episode
    {
        public string EpisodeName { get; set; }
        public string EpisodeDescription { get; set; }

        public Episode()
        {

        }

        public Episode(string name, string description)
        {
            EpisodeName = name;

            EpisodeDescription = description;
        }
    }
}
