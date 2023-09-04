using ProjectManagement.Modules.Comments.Application.Dtos;
using ProjectManagement.Modules.Comments.Application.Ports.Input;
using ProjectManagement.Modules.Comments.Application.Ports.Output;
using ProjectManagement.Modules.Comments.Domain.Entities;
using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Commons.Domain.Exceptions;

namespace ProjectManagement.Modules.Comments.Application.UseCases
{
    public class CommentUseCase : ICommentUseCase
    {

        private readonly ICommentRepository _commentRepository;

        public CommentUseCase(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Delete(int TaskId, int CommentId)
        {

            var Exist = await _commentRepository.Exist(TaskId, CommentId);

            if (!Exist)
                throw new CustomNotFoundException($"The Comment with the id: {CommentId} does not exist");

            await _commentRepository.Delete(TaskId, CommentId);
        }

        public async Task<PaginatedDataDto<CommentDomain>> FindAll(int TaskId, CommentRequestParams requestParams)
        {

            return await _commentRepository.FindAll(TaskId,requestParams);
        }

        public async Task<CommentResponseDto> FindById(int TaskId, int CommentId)
        {
            var Exist= await _commentRepository.Exist(TaskId, CommentId);

            if (!Exist)
                throw new CustomNotFoundException($"The Comment with the id: {CommentId} does not exist");

            var Comment = await _commentRepository.FindById(TaskId, CommentId);

            return CommentMapperDto.MapToDto(Comment);
        }

        public async Task<CommentResponseDto> Save(int proyectId,CommentRequestDto commentRequest)
        {

           var CommentDomain=CommentMapperDto.MapToDomain(0,commentRequest);

           var comment=await _commentRepository.Save(proyectId,commentRequest.AsignedUserId, CommentDomain);


           return CommentMapperDto.MapToDto(comment);
        }

        public async Task<CommentResponseDto> Update(int TaskId, int CommentId, CommentRequestDto commentRequest)
        {
            var Exist = await _commentRepository.Exist(TaskId, CommentId);

            if (!Exist)
                throw new CustomNotFoundException($"The Comment with the id: {CommentId} does not exist");

            var CommentDomain = CommentMapperDto.MapToDomain(CommentId,commentRequest);

            CommentDomain = await _commentRepository.Update(TaskId,commentRequest.AsignedUserId,CommentDomain);


            return CommentMapperDto.MapToDto(CommentDomain);
        }
    }
}
