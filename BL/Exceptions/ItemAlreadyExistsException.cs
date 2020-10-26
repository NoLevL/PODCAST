using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions
{
    class ItemAlreadyExistsException : Exception
    {

        public ItemAlreadyExistsException()
            : base()
        { }


        public ItemAlreadyExistsException(string message)
            : base(message)
        { }
    }
}
