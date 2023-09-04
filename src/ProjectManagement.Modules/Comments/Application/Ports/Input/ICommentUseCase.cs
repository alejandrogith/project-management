using ProjectManagement.Modules.Comments.Application.Dtos;
using ProjectManagement.Modules.Comments.Domain.Entities;
using ProjectManagement.Modules.Commons.Application.Dtos;

namespace ProjectManagement.Modules.Comments.Application.Ports.Input
{
    public interface ICommentUseCase
    {
        public Task<CommentResponseDto> Save(int TaskId, CommentRequestDto commentRequest);

        public Task<CommentResponseDto> FindById(int TaskId, int CommentId);


        public Task<PaginatedDataDto<CommentDomain>> FindAll(int TaskId,CommentRequestParams requestParams);


        public Task<CommentResponseDto> Update(int TaskId,int CommentId, CommentRequestDto commentRequest);


        public Task Delete(int TaskId, int CommentId);
    }
}
