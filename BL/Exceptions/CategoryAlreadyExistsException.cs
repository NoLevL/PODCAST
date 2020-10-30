using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.Exceptions
{
    class CategoryAlreadyExistsException : Exception
    {
        string msg = "Category already exists!";
        public CategoryAlreadyExistsException()
            : base()
        { MessageBox.Show(msg); }


        public CategoryAlreadyExistsException(string message)
            : base(message)
        { }


        public CategoryAlreadyExistsException(string message, Exception innerException)
            : base (message, innerException)
        { }
    }
}
