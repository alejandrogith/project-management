using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Commons.Domain.Exceptions;
using ProjectManagement.Modules.Tasks.Application.Dtos;
using ProjectManagement.Modules.Tasks.Application.ports.Input;
using ProjectManagement.Modules.Tasks.Application.ports.Output;
using ProjectManagement.Modules.Tasks.Domain.Entities;


public class TaskUseCase : ITaskUseCase
{

    private readonly ITaskRepository _taskRepository;

    public TaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task Delete(int proyectId,int Id)
    {
        var Exist = await _taskRepository.Exist(proyectId, Id);

        if (!Exist)
            throw new CustomNotFoundException($"The Task with the id: {Id} does not exist");

         await _taskRepository.Delete(Id);

       
    }

    public async Task<PaginatedDataDto<TaskDomain>> FindAll( int proyectId,TaskRequestParams reqParams)
    {
        return await  _taskRepository.FindAll(proyectId,reqParams);
    }

    public async Task<TaskResponseDto> FindById(int proyectId, int Id)
    {
        var Exist=await _taskRepository.Exist( proyectId, Id);

        if (!Exist)
            throw new CustomNotFoundException($"The Task with the id: {Id} does not exist");

        var Task= await _taskRepository.FindById(Id);
    
        return TaskMapperDto.MapToDto(Task);
    }

    public async Task<TaskResponseDto> Save(int proyectId,TaskRequestDto taskDomain)
    {
        var Task = TaskMapperDto.MapToDomain(taskDomain);
        
        Task= await _taskRepository.Save(proyectId,Task);

        return TaskMapperDto.MapToDto(Task); 
    }

    public async Task<TaskResponseDto> Update(int proyectId,int Id, TaskRequestDto proyectRequest)
    {
        var Exist = await _taskRepository.Exist(proyectId, Id);

        if (!Exist)
            throw new CustomNotFoundException($"The Task with the id: {Id} does not exist");

        
        var Task=TaskMapperDto.MapToDomain(proyectRequest);
        Task.Id = Id;

        Task = await _taskRepository.Update(proyectId,Task);

        return TaskMapperDto.MapToDto(Task);
    }
}

