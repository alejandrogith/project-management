using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Tasks.Application.Dtos;
using ProjectManagement.Modules.Tasks.Domain.Entities;

namespace ProjectManagement.Modules.Tasks.Application.ports.Output
{
    public interface ITaskRepository
    {

        public Task<TaskDomain> Save(int proyectId,TaskDomain task);

         public Task<PaginatedDataDto<TaskDomain>> FindAll(int proyectId,TaskRequestParams reqParams);

         public Task<TaskDomain> FindById(int Id);

         public Task<bool> Exist(int proyectId, int Id);

        public Task Update(int proyectId,TaskDomain task);


        public Task Delete(int Id);
    }
}
