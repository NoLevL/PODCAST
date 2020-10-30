using System;
using System.Windows.Forms;

namespace BL.Exceptions
{
    class ComboBoxIsNullException : Exception
    {
        string msg = "You must pick an item in the ";

        public ComboBoxIsNullException()
            : base()
        { MessageBox.Show(msg); }


        public ComboBoxIsNullException(string message)
            : base(message)
        { MessageBox.Show(msg + message); }


        public ComboBoxIsNullException(string message, Exception innerException)
            : base (message, innerException)
        { }
    }
}
