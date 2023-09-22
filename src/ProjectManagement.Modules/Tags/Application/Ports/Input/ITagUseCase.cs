using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Tags.Application.Dtos;
using ProjectManagement.Modules.Tags.Domain.Entitites;

namespace ProjectManagement.Modules.Tags.Application.Ports.Input
{
    public interface ITagUseCase
    {
        public Task<TagResponseDto> Save(TagRequestDto tagRequestDto);

        public Task<TagResponseDto> FindById(int TagId);

        public Task<PaginatedDataDto<TagDomain>> FindAll(TagRequestParams requestParams);

        public Task Update(int TagId, TagRequestDto tagRequestDto);

        public Task Delete(int TagId);
    }
}
