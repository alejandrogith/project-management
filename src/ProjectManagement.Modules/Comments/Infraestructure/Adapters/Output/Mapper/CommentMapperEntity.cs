using ProjectManagement.Modules.Comments.Application.Dtos;
using ProjectManagement.Modules.Comments.Domain.Entities;
using ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Entity;

namespace ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Mapper
{
    public static class CommentMapperEntity
    {

        public static CommentEntity MapToEntity(int taskId,string AssignedUserId, CommentDomain comment)
        {
            return new CommentEntity( comment.Id, comment.Content, taskId,AssignedUserId);
        }

        public static CommentDomain MapToDomain(string TaskName,string UserName, CommentEntity comment)
        {
            return new CommentDomain(comment.Id, comment.Content, UserName, TaskName,comment.CreatedAt,comment.UpdatedAt);
        }
    }
}
