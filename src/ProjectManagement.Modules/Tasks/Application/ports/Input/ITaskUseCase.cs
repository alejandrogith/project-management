using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Proyects.Application.Dtos;
using ProjectManagement.Modules.Proyects.Domain.Entities;
using ProjectManagement.Modules.Tasks.Application.Dtos;
using ProjectManagement.Modules.Tasks.Domain.Entities;

namespace ProjectManagement.Modules.Tasks.Application.ports.Input
{

    public interface ITaskUseCase
    {
        public Task<TaskResponseDto> Save(int proyectId,TaskRequestDto taskDomain);


        public Task<PaginatedDataDto<TaskDomain>> FindAll(int proyectId,TaskRequestParams reqParams);


        public Task<TaskResponseDto> FindById(int proyectId,int Id);

        public Task<TaskResponseDto> Update(int proyectId,int Id, TaskRequestDto proyectRequest);

        public Task Delete(int proyectId,int Id);

    }
}
