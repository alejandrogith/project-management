using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Errors
{
    public class CustomUnauthorizedException : Exception
    {
        public CustomUnauthorizedException(string message) : base(message)
        {

        }
    }
}
