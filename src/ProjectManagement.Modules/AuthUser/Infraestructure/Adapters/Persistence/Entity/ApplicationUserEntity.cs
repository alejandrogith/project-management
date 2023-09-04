using Microsoft.AspNetCore.Identity;
using ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Entity;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Entity;

namespace ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string email, string userName,string name, string lastName)
        {
            Name = name;
            LastName = lastName;
            this.Email = email;
            this.UserName = userName;
        }

        public string Name { get; set; }

        public string LastName { get; set; }


        public List<TaskEntity> Tasks { get; set; }

        public List<CommentEntity> Comments { get; set; }

    }
}
