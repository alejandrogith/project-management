using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Modules.Tasks.Application.ports.Input;
using ProjectManagement.Modules.Tasks.Application.ports.Output;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Repository;

namespace ProjectManagement.Modules.Tasks.Infraestructure
{
    public static class ServiceExtensions 
    {
        public static void AddTaskModule(this IServiceCollection Services) {



            Services.AddScoped<ITaskUseCase, TaskUseCase>();
            Services.AddScoped<ITaskRepository, TaskRepository>();
        }






    }
}
