using ProjectManagement.Modules.Tasks.Domain.Entities;

namespace ProjectManagement.Modules.Tasks.Application.Dtos
{
    public static class TaskMapperDto
    {

        public static  TaskResponseDto MapToDto(TaskDomain task)
        {
            if (task == null) return null;

            return new TaskResponseDto(task.Id, task.Title, task.Description, task.State, task.Priority, task.Type,task.AssignedUser, task.Proyect,task.CreatedAt,task.UpdatedAt);
        }

        
        public static TaskDomain MapToDomain(TaskRequestDto taskRequest)
        {

            if (taskRequest == null) return null;

            return new TaskDomain
            {
                Title = taskRequest.Title,
                Description = taskRequest.Description,
                State = taskRequest.State,
                Priority = taskRequest.Priority,
                Type = taskRequest.Type,
                AssignedUser=taskRequest.AssignedUserId,
    
            };
        }
        

    }
}
