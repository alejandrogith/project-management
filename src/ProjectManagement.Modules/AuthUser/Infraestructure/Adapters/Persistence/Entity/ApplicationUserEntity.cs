using Microsoft.AspNetCore.Identity;
using ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Entity;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Entity;

namespace ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Entity
{
    public class ApplicationUser : IdentityUser
    {





        public List<TaskEntity> Tasks { get; set; }

        public List<CommentEntity> Comments { get; set; }

    }
}
