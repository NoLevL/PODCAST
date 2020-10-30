using System;
using System.Windows.Forms;

namespace BL.Exceptions
{
    class ComboBoxIntervalIsNullException : Exception
    {
        string msg = "You must choose an interval!";

        public ComboBoxIntervalIsNullException()
            : base()
        { MessageBox.Show(msg); }


        public ComboBoxIntervalIsNullException(string message)
            : base(message)
        { }


        public ComboBoxIntervalIsNullException(string message, Exception innerException)
            : base (message, innerException)
        { }
    }
}
