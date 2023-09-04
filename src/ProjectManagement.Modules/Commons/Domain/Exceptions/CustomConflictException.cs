using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Modules.Commons.Domain.Exceptions
{
    public class CustomConflictException : Exception
    {
        public CustomConflictException(string message) : base(message)
        {

        }
    }
}