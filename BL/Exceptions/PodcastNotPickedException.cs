using System;
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
        { MessageBox.Show(msg + message); }


        public PodcastNotPickedException(string message, Exception innerException)
            : base(message, innerException)
        { MessageBox.Show(msg + message + innerException); }
    }
}
