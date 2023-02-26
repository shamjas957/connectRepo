using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectApi.Core.Common.Exceptions
{
    public class InputValidationException : BaseException 
    {
        public InputValidationException(string message) :base(message)
        {

        }
    }
}
