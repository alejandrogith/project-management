using Mapster;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Commons.Infraestructure.Persistence;
using ProjectManagement.Modules.Tags.Application.Dtos;
using ProjectManagement.Modules.Tags.Application.Ports.Output;
using ProjectManagement.Modules.Tags.Domain.Entitites;
using ProjectManagement.Modules.Tags.Infraestructure.Adapters.Output.Persistence.Entity;
using ProjectManagement.Modules.Tags.Infraestructure.Adapters.Output.Persistence.Mapper;

namespace ProjectManagement.Modules.Tags.Infraestructure.Adapters.Output.Persistence.Repository
{
    public class TagRepository : ITagRepository
    {

        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int TagId)
        {
             _context.TagEntity.Remove(new TagEntity { Id = TagId });
           await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int TagId)
        {
            return await _context.TagEntity.Where(x => x.Id == TagId).CountAsync()>0 ;
        }

        public async Task<PaginatedDataDto<TagDomain>> FindAll(TagRequestParams requestParams)
        {
            IQueryable<TagEntity> Query = _context.TagEntity;

            if (!string.IsNullOrEmpty(requestParams.Search))
            {
                Query = Query.Where(x =>
                x.Name.Contains(requestParams.Search));

            }


            if (!string.IsNullOrEmpty(requestParams.Sort))
            {
                Query = requestParams.Sort switch
                {
                    "nameAsc" => Query.OrderBy(x => x.Id),
                    "nameDesc" => Query.OrderByDescending(x => x.Id),
                    _ => Query.OrderBy(x => x.Id)
                };
            }

            var Tags = await Query
                            .Skip(requestParams.PageSize * (requestParams.PageIndex - 1))
                            .Take(requestParams.PageSize)
                            .Select(x => x.Adapt<TagDomain>())
                            .AsNoTracking()
                            .ToListAsync();

            var count = await Query.CountAsync();


            var Data = new PaginatedDataDto<TagDomain>(Tags, requestParams.PageIndex, requestParams.PageSize, count);


            return Data;
        }

        public async Task<TagDomain> FindById(int TagId)
        {
            var Tag= await _context.TagEntity.Where(x => x.Id == TagId).FirstOrDefaultAsync() ;

            return Tag.Adapt<TagDomain>();
        }

        public async Task<TagDomain> Save(TagDomain tagDomain)
        {
            var tagEntity=tagDomain.Adapt<TagEntity>();

            await _context.TagEntity.AddAsync(tagEntity);
            await _context.SaveChangesAsync();

            return tagEntity.Adapt<TagDomain>();
        }

        public async Task Update(TagDomain tagDomain)
        {
            var tagEntity = tagDomain.Adapt<TagEntity>();

            tagEntity.CreatedAt = await _context.TagEntity.Where(x=>x.Id==tagEntity.Id)
                                                            .Select(x=>x.CreatedAt)
                                                            .FirstOrDefaultAsync(); 
            
             _context.TagEntity.Update(tagEntity);
             await _context.SaveChangesAsync();


        }
    }
}
