using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions
{
    class ComboBoxIsNullException : Exception
    {

        public ComboBoxIsNullException()
            : base()
        { }


        public ComboBoxIsNullException(string message)
            : base(message)
        { }
    }
}
