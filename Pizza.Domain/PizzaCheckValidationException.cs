using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain
{
    public class PizzaCheckValidationException : Exception
    {

        public string Message;

        public PizzaCheckValidationException(string Message)
        {
            this.Message = Message;
        }
    }
}
