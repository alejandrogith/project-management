using ProjectManagement.Modules.Comments.Application.Dtos;
using ProjectManagement.Modules.Comments.Domain.Entities;
using ProjectManagement.Modules.Commons.Application.Dtos;

namespace ProjectManagement.Modules.Comments.Application.Ports.Output
{
    public interface ICommentRepository
    {
        public Task<CommentDomain> Save(int taskId,string AsignedUserId, CommentDomain commentDomain);

        public Task<CommentDomain> FindById(int taskId, int CommentId);

        public Task<bool> Exist(int taskId, int CommentId);

        public Task<PaginatedDataDto<CommentDomain>> FindAll(int taskId,CommentRequestParams requestParams);

        public Task<CommentDomain> Update(int taskId, string AsignedUserId, CommentDomain commentDomain);

        public Task Delete(int taskId, int CommentId);
    }
}
