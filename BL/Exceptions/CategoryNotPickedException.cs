using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.Exceptions
{
    class CategoryNotPickedException : Exception
    {
        string msg = "You must choose a categpry to continue!";
        public CategoryNotPickedException()
            : base()
        { MessageBox.Show(msg); }


        public CategoryNotPickedException(string message)
            : base(message)
        { }


        public CategoryNotPickedException(string message, Exception innerException)
            : base(message, innerException)
        { }

    }
}
