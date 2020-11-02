using System;
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
        { MessageBox.Show(msg + message); }


        public PodcastAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        { MessageBox.Show(msg + message + innerException); }
    }
}
