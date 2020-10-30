using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.Exceptions
{
    class PodcastNotPickedException : Exception
    {
        string msg = "You must choose a podcast to delete!";
        public PodcastNotPickedException()
            : base()
        { MessageBox.Show(msg); }


        public PodcastNotPickedException(string message)
            : base(message)
        { }


        public PodcastNotPickedException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
