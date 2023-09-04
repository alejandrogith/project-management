using Microsoft.EntityFrameworkCore;
using ProjectManagement.Modules.Comments.Application.Dtos;
using ProjectManagement.Modules.Comments.Application.Ports.Output;
using ProjectManagement.Modules.Comments.Domain.Entities;
using ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Entity;
using ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Mapper;
using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Commons.Infraestructure.Persistence;
using ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Mapper;

namespace ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(int taskId, int CommentId)
        {
            _dbContext.CommentEntity.Remove(new CommentEntity() { Id = CommentId, TaskId =taskId });
           await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int taskId, int CommentId)
        {
            return  await _dbContext.CommentEntity
                            .Where(x => x.Id == CommentId && x.TaskId == taskId)
                            .CountAsync() >0;                    
        }

        public async Task<PaginatedDataDto<CommentDomain>> FindAll(int taskId, CommentRequestParams requestParams)
        {
            IQueryable<CommentEntity> Query = _dbContext.CommentEntity;

            if (!string.IsNullOrEmpty(requestParams.Search))
                Query = Query.Where(x => x.Content.Contains(requestParams.Search));


                Query = Query.Where(x => x.TaskId == taskId);

            if (!string.IsNullOrEmpty(requestParams.Sort))
            {
                Query = requestParams.Sort switch
                {   
                    "contentAsc" => Query.OrderBy(x => x.Content),
                    "contentDesc" => Query.OrderByDescending(x => x.Content),
                    _ => Query.OrderBy(x => x.Content)
                };
            }

            var Comments = await Query
                            .Skip(requestParams.PageSize * (requestParams.PageIndex - 1))
                            .Take(requestParams.PageSize)
                            .Select(x => CommentMapperEntity.MapToDomain(x.Task.Title, x.CreatorUser.Name, x))
                            .AsNoTracking()
                            .ToListAsync();

            var count = await Query.CountAsync();

            var Data = new PaginatedDataDto<CommentDomain>(Comments, requestParams.PageIndex, requestParams.PageSize, count);

            return Data;
        }

        public async Task<CommentDomain> FindById(int taskId, int CommentId)
        {
            var Comment = await _dbContext.CommentEntity.Where(x => x.Id ==CommentId && x.TaskId==taskId)
                               .Select(x => CommentMapperEntity.MapToDomain(x.Task.Title, x.CreatorUser.Name, x))
                               .FirstOrDefaultAsync();

            return Comment;
        }

        public async Task<CommentDomain> Save(int taskId, string AsignedUserId, CommentDomain commentDomain)
        {
            var CommentEntity=CommentMapperEntity.MapToEntity(taskId, AsignedUserId,commentDomain);

            await _dbContext.CommentEntity.AddAsync(CommentEntity);
            await _dbContext.SaveChangesAsync();

            var Comment =await _dbContext.CommentEntity.Where(x => x.Id == CommentEntity.Id)
                                           .Select(x => CommentMapperEntity.MapToDomain(x.Task.Title,x.CreatorUser.Name,x ))
                                           .FirstOrDefaultAsync();

            return Comment;
        }

        public async Task<CommentDomain> Update(int taskId, string AsignedUserId, CommentDomain commentDomain)
        {
            var CommentEntity = CommentMapperEntity.MapToEntity(taskId, AsignedUserId, commentDomain);
            CommentEntity.CreatedAt = await _dbContext.CommentEntity.Where(x => x.Id == CommentEntity.Id)
                                                            .Select(x => x.CreatedAt)
                                                            .FirstOrDefaultAsync();

            _dbContext.CommentEntity.Update(CommentEntity);
            await _dbContext.SaveChangesAsync();

            var Comment = await _dbContext.CommentEntity.Where(x => x.Id == CommentEntity.Id)
                               .Select(x => CommentMapperEntity.MapToDomain(x.Task.Title, x.CreatorUser.Name, x))
                               .FirstOrDefaultAsync();

            return Comment;
        }






    }
}
