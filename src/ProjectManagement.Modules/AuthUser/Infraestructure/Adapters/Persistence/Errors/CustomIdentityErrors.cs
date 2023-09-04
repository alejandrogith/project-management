using System.Text.Json;

namespace ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Errors
{
    public class CustomIdentityErrors:Exception
    {
        public CustomIdentityErrors(List<string> Errors)  {  
        
        this.Errors = Errors;
        }
        public List<string> Errors { get; set; }
    }
}
