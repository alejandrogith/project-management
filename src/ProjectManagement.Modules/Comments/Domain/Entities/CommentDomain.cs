using ProjectManagement.Modules.Commons.Infraestructure.Persistence;

namespace ProjectManagement.Modules.Comments.Domain.Entities
{
    public class CommentDomain:BaseAuditableEntity
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public int TaskId { get; set; }

      

    }
}
