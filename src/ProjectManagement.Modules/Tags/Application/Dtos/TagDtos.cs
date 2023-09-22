using ProjectManagement.Modules.Commons.Application.Dtos;

namespace ProjectManagement.Modules.Tags.Application.Dtos
{
    public record TagRequestDto(string Name);
    public record TagResponseDto(int Id, string Name,DateTime? CreatedAt,DateTime? UpdatedAt);

    public class TagRequestParams : BaseRequestParams
    {
        public string? Search { get; set; }
    }


}
