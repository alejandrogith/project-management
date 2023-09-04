using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Modules.Tags.Application.Ports.Input;
using ProjectManagement.Modules.Tags.Application.Ports.Output;
using ProjectManagement.Modules.Tags.Application.UseCases;
using ProjectManagement.Modules.Tags.Infraestructure.Adapters.Output.Persistence.Repository;

namespace ProjectManagement.Modules.Tags.Infraestructure
{
    public static class ServiceExtensions
    {
        public static void AddTagModule(this IServiceCollection Services)
        {
            Services.AddScoped<ITagUseCase, TagUseCase>();
           Services.AddScoped<ITagRepository, TagRepository>();
        }


    }
}
