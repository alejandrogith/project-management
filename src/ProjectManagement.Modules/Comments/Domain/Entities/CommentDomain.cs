using ProjectManagement.Modules.Commons.Infraestructure.Persistence;

namespace ProjectManagement.Modules.Comments.Domain.Entities
{
    public class CommentDomain:BaseAuditableEntity
    {
        public CommentDomain(int id, string content, string asignedUser, string taskName,DateTime? createdAt,DateTime? updatedAt)
        {
            Id = id;
            Content = content;
            AsignedUser = asignedUser;
            TaskName = taskName;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public string AsignedUser { get; set; }
        public string TaskName { get; set; }

      

    }
}
