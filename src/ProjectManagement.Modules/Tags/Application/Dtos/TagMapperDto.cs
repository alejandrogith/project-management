

using ProjectManagement.Modules.Tags.Domain.Entitites;

namespace ProjectManagement.Modules.Tags.Application.Dtos
{
    public static class TagMapperDto
    {
        public static TagDomain MapToDomain(int TagId, TagRequestDto dto)
        {
            return null;
        }

        public static TagResponseDto MapToDto(TagDomain domain)
        {
            return new TagResponseDto(domain.Id,domain.Name,domain.CreatedAt,domain.UpdatedAt);
        }

    }
}
