using Mapster;
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

            return Comment.Adapt<CommentResponseDto>();
        }

        public async Task<CommentResponseDto> Save(CommentRequestDto commentRequest)
        {

           var CommentDomain=commentRequest.Adapt<CommentDomain>();

           var comment=await _commentRepository.Save(CommentDomain);


           return comment.Adapt<CommentResponseDto>();
        }

        public async Task Update(int TaskId, int CommentId, CommentRequestDto commentRequest)
        {
            var Exist = await _commentRepository.Exist(TaskId, CommentId);

            if (!Exist)
                throw new CustomNotFoundException($"The Comment with the id: {CommentId} does not exist");

            var CommentDomain = commentRequest.Adapt<CommentDomain>();

            CommentDomain.Id = CommentId;

            await _commentRepository.Update(CommentDomain);



        }
    }
}
