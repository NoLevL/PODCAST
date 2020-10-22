using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class Podcast : //IPodcastRepository
    {
        public string Url { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Episodes { get; set; }
    }
}
