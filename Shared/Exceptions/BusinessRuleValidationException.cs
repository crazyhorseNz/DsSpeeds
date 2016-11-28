using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException() : base()
        {
        }

        public BusinessRuleValidationException(string message) : base(message)
        {
        }
    }
}
