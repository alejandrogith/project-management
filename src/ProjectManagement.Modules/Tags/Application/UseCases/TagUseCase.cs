using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Commons.Domain.Exceptions;
using ProjectManagement.Modules.Tags.Application.Dtos;
using ProjectManagement.Modules.Tags.Application.Ports.Input;
using ProjectManagement.Modules.Tags.Application.Ports.Output;
using ProjectManagement.Modules.Tags.Domain.Entitites;

namespace ProjectManagement.Modules.Tags.Application.UseCases
{
    public class TagUseCase : ITagUseCase
    {
        private readonly ITagRepository _tagRepository;

        public TagUseCase(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task Delete(int TagId)
        {
            var Exist = await _tagRepository.Exist(TagId);

            if (!Exist)
                throw new CustomNotFoundException($"The Tag with the id: {TagId} does not exist");

            await  _tagRepository.Delete(TagId);
        }

        public async Task<PaginatedDataDto<TagDomain>> FindAll(TagRequestParams requestParams)
        {
            return await _tagRepository.FindAll(requestParams);
        }

        public async Task<TagResponseDto> FindById(int TagId)
        {
            var Exist = await _tagRepository.Exist(TagId);

            if (!Exist)
                throw new CustomNotFoundException($"The Tag with the id: {TagId} does not exist");

            var Tag=await _tagRepository.FindById(TagId);

            return TagMapperDto.MapToDto(Tag);
        }

        public async Task<TagResponseDto> Save(TagRequestDto tagRequestDto)
        {
           var TagDomain = TagMapperDto.MapToDomain(0,tagRequestDto);

           TagDomain= await _tagRepository.Save(TagDomain);
        
            return TagMapperDto.MapToDto(TagDomain);
        }

        public async Task<TagResponseDto> Update(int TagId, TagRequestDto tagRequestDto)
        {
            var Exist = await _tagRepository.Exist(TagId);

            if (!Exist)
                throw new CustomNotFoundException($"The Tag with the id: {TagId} does not exist");

            var TagDomain = TagMapperDto.MapToDomain(TagId, tagRequestDto);

            TagDomain= await _tagRepository.Update(TagDomain);

            return TagMapperDto.MapToDto(TagDomain);
        }
    }
}
