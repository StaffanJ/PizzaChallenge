using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain
{
    public class CustomerCheckValidationException : Exception
    {
        public string Message;

        public CustomerCheckValidationException(string Message)
        {
            this.Message = Message;
        }
    }
}
