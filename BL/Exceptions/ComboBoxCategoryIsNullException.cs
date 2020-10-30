using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.Exceptions
{
    class ComboBoxCategoryIsNullException : Exception
    {
        string msg = "You must choose a category!";

        public ComboBoxCategoryIsNullException()
            : base()
        { MessageBox.Show(msg); }


        public ComboBoxCategoryIsNullException(string message)
            : base(message)
        { }


        public ComboBoxCategoryIsNullException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
