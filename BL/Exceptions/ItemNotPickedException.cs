using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions
{
    class ItemNotPickedException : Exception
    {

        public ItemNotPickedException()
            : base()
        { }


        public ItemNotPickedException(string message)
            : base(message)
        { }

    }
}
