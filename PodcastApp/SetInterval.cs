using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastApp
{
    class SetInterval
    {

        public DateTime NextUpdate { get; set; }

        public double UpdateInterval { get; set; }


        public SetInterval(double updateInterval)
        {
            UpdateInterval = updateInterval;
            Update();
        }


        public bool NeedsUpdate
        {
            get
            {
                return NextUpdate <= DateTime.Now;
            }
        }


        public string Update()
        {
            NextUpdate = DateTime.Now.AddMinutes(UpdateInterval);
            return "Next update is at " + NextUpdate;
        }
    }
}
