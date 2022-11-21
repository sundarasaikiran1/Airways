using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginException
{
    [Serializable]
    public class UserException : Exception
    {
        public UserException()
        {

        }
        public UserException(string message): base(message) { }
        public UserException(string message, Exception innerException): base(message, innerException) { }   
        protected UserException (System.Runtime.Serialization.SerializationInfo info,System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {

        }
    }
}
