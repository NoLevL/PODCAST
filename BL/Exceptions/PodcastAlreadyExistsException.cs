using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.Exceptions
{
    class PodcastAlreadyExistsException : Exception
    {
        string msg = "Podcast already exists!";
        public PodcastAlreadyExistsException()
            : base()
        { MessageBox.Show(msg); }


        public PodcastAlreadyExistsException(string message)
            : base(message)
        { }


        public PodcastAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
