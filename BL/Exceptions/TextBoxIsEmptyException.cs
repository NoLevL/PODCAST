using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions
{
    class TextBoxCategoryIsEmptyException : Exception
    {
        public TextBoxCategoryIsEmptyException()
            : base()
        { }
        


        public TextBoxCategoryIsEmptyException(string message)
            : base(message)
        { }
    }
}
