using Mapster;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Commons.Infraestructure.Persistence;
using ProjectManagement.Modules.Tasks.Application.Dtos;
using ProjectManagement.Modules.Tasks.Application.ports.Output;
using ProjectManagement.Modules.Tasks.Domain.Entities;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Entity;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Mapper;

namespace ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Repository
{
    internal class TaskRepository : ITaskRepository
    {

        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int Id)
        {

            var Entity = TaskMapperEntity.MapToEntity(0,new TaskDomain() { Id = Id });

            _context.TaskEntity.Remove(Entity);

            await _context.SaveChangesAsync();


        }

        public async Task<bool> Exist(int proyectId, int Id)
        {
            return await _context.TaskEntity.Where(x => x.Id == Id  && x.ProyectId==proyectId).CountAsync() > 0;
        }

        public async Task<PaginatedDataDto<TaskDomain>> FindAll(int proyectId,TaskRequestParams reqParams)
        {
            IQueryable<TaskEntity> Query = _context.TaskEntity;

            if (!string.IsNullOrEmpty(reqParams.Search))  
                Query = Query.Where(x =>x.Title.Contains(reqParams.Search));

            if (proyectId>0)
                Query = Query.Where(x => x.ProyectId==proyectId);

            if (!string.IsNullOrEmpty(reqParams.Sort))
            {
                Query = reqParams.Sort switch
                {
                    "titleAsc" => Query.OrderBy(x => x.Title),
                    "titleDesc" => Query.OrderByDescending(x => x.Title),
                    _ => Query.OrderBy(x => x.Title)
                };
            }

            var Tasks = await Query
                            .Skip(reqParams.PageSize * (reqParams.PageIndex - 1))
                            .Take(reqParams.PageSize)
                            .Select(x => TaskMapperEntity.MapToDomain(x,x.Proyect.Nombre,x.AssignedUser.UserName))
                            .AsNoTracking()
                            .ToListAsync();

            var count = await Query.CountAsync();

            var Data = new PaginatedDataDto<TaskDomain>(Tasks, reqParams.PageIndex, reqParams.PageSize, count);

            return Data;

        }

        public async Task<TaskDomain> FindById(int Id)
        {
            var task = await _context.TaskEntity
                            .Where(x=>x.Id==Id)
                            .Select(x => TaskMapperEntity.MapToDomain(x, x.Proyect.Id.ToString(), x.AssignedUser.Id))
                            .AsNoTracking()
                            .FirstOrDefaultAsync();
            return task;
        }

        public async Task<TaskDomain> Save(int proyectId, TaskDomain task)
        {

            var Entity = task.Adapt<TaskEntity>();
            Entity.ProyectId=proyectId;

            await _context.TaskEntity.AddAsync(Entity);
            await _context.SaveChangesAsync();


            var taskInfo = await _context.TaskEntity
                        .Where(x => x.Id == Entity.Id)
                        .Select(x => TaskMapperEntity.MapToDomain(x, x.Proyect.Id.ToString(), x.AssignedUser.Id))
                        .FirstOrDefaultAsync();

            return taskInfo;
        }

        public async Task Update(int proyectId,TaskDomain task)
        {
            var TaskEntity = TaskMapperEntity.MapToEntity(proyectId, task);


            TaskEntity.CreatedAt = await _context.TaskEntity
                        .Where(x => x.Id == TaskEntity.Id)
                        .Select(x => x.CreatedAt).FirstOrDefaultAsync();

            _context.TaskEntity.Update(TaskEntity);
            await _context.SaveChangesAsync();



           
        }
    }
}
