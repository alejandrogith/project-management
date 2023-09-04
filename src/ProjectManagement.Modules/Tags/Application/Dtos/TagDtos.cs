using ProjectManagement.Modules.Commons.Application.Dtos;

namespace ProjectManagement.Modules.Tags.Application.Dtos
{
    public record TagRequestDto(string Name);
    public record TagResponseDto(int TaskId, string Name,DateTime? CreateAt,DateTime? UpdateAt);

    public class TagRequestParams : BaseRequestParams
    {
        public string? Search { get; set; }
    }


}
