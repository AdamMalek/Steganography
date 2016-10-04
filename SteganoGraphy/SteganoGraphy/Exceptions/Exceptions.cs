using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganoGraphy.Exceptions
{
    public class InvalidFileException : ApplicationException { }
    public class NoFileLoadedException : ApplicationException
    {
        private string _msg;

        public override string Message
        {
            get
            {
                return _msg;
            }
        }
        public NoFileLoadedException(string msg="No image was loaded!")
        {
            _msg = msg;
        }
    }

    public class MessageTooLongException : ApplicationException
    {
        private string _msg;

        public override string Message
        {
            get
            {
                return _msg;
            }
        }
        public MessageTooLongException(string msg = "Message is too long!")
        {
            _msg = msg;
        }
    }
}
