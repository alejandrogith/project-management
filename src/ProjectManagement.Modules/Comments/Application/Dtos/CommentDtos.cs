using ProjectManagement.Modules.Commons.Application.Dtos;

namespace ProjectManagement.Modules.Comments.Application.Dtos
{
    public record CommentRequestDto(string Comment,string AsignedUserId);

    public record CommentResponseDto(int CommentId,string Comment, string AsignedUser,string TaskName,DateTime? CreatedAt,DateTime? UpdatedAt);


    public class CommentRequestParams : BaseRequestParams
    {
        public string? Search { get; set; }
    }
}
