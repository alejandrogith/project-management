using ProjectManagement.Modules.Tasks.Domain.Entities;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Entity;

namespace ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Mapper
{
    public static class TaskMapperEntity
    {

        public static TaskDomain MapToDomain(TaskEntity task,string proyect="",string asignedUser = "")
        {
            if (task is null) return null;

            return new TaskDomain
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                State = task.State,
                Priority = task.Priority,
                Type = task.Type,
                AssignedUser = asignedUser,
                Proyect = proyect,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt,
                
            };
        }

        public static TaskEntity MapToEntity(int proyectId,TaskDomain domain)
        {

            if (domain is null) return null;

            return new TaskEntity
            {
                Id = domain.Id,
                Title = domain.Title,
                Description = domain.Description,
                State = domain.State,
                Priority = domain.Priority,
                Type = domain.Type,
                AssignedUserId = domain.AssignedUser,
                ProyectId = proyectId

            };
        }

    }
}
