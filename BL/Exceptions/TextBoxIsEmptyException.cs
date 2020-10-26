using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions
{
    public class TextBoxIsEmptyException : Exception
    {
        public TextBoxIsEmptyException()
            : base()
        { }
        


        public TextBoxIsEmptyException(string message)
            : base(message)
        { }


        public TextBoxIsEmptyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
