using System;
using System.Windows.Forms;

namespace BL.Exceptions
{
    public class TextBoxIsEmptyException : Exception
    {
        string msg = "You must enter something in the textbox to proceed!";
        public TextBoxIsEmptyException()
            : base()
        { MessageBox.Show(msg); }
        


        public TextBoxIsEmptyException(string message)
            : base(message)
        { }


        public TextBoxIsEmptyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
