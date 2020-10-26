using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions
{
    class ListIsEmptyException : Exception
    {

        public ListIsEmptyException()
            : base()
        { }


        public ListIsEmptyException(string message)
            : base(message)
        { }
    }
}
