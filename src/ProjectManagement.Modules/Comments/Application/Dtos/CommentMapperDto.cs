using ProjectManagement.Modules.Comments.Domain.Entities;

namespace ProjectManagement.Modules.Comments.Application.Dtos
{
    public class CommentMapperDto
    {
        public static CommentResponseDto MapToDto(CommentDomain comment)
        {
            return new CommentResponseDto(comment.Id, comment.Content, comment.AsignedUser,comment.TaskName,comment.CreatedAt,comment.UpdatedAt);
        }

        public static CommentDomain MapToDomain(int CommentId,CommentRequestDto request)
        {
            return new CommentDomain(CommentId, request.Comment, "","",null,null);
        }
    }
}
