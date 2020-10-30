using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Feed
    {
        public virtual string GetDateInfo(string url, Episode episode)
        {
            string stringToBeReturned = "";
            return stringToBeReturned;
        }
    }
}
