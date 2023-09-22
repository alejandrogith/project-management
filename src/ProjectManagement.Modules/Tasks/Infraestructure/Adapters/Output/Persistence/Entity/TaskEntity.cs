using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Entity;
using ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Entity;
using ProjectManagement.Modules.Commons.Infraestructure.Persistence;
using ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Entity;
using ProjectManagement.Modules.Tags.Infraestructure.Adapters.Output.Persistence.Entity;

namespace ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Entity
{
    public class TaskEntity:BaseAuditableEntity
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string?   Description { get; set; }
        public string? State { get; set; }
        public string? Priority { get; set; }
        public string? Type { get; set; }

        public string? AssignedUserId { get; set; }
        public ApplicationUser AssignedUser { get; set; }


        public int ProyectId { get; set; }
        public ProyectEntity Proyect { get; set; }

        public List<CommentEntity> Comments { get; set; }

        public int TagId { get; set; }
        public TagEntity Tag { get; set; }

    }
}
