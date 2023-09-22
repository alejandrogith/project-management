using ProjectManagement.Modules.Commons.Application.Dtos;

namespace ProjectManagement.Modules.Comments.Application.Dtos
{
    public record CommentRequestDto(string Content, string UserId, int TaskId);

    public record CommentResponseDto(int Id,string Content, string UserId, int TaskId, DateTime? CreatedAt,DateTime? UpdatedAt);


    public class CommentRequestParams : BaseRequestParams
    {
        public string? Search { get; set; }
    }
}
