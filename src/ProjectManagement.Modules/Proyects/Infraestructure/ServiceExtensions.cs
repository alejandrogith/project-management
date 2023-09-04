using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Modules.Proyects.Application.Ports.Input;
using ProjectManagement.Modules.Proyects.Application.Ports.Output;
using ProjectManagement.Modules.Proyects.Application.ServicesUseCases;
using ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Repository;

namespace ProjectManagement.Modules.Proyects.Infraestructure
{
    public static class ServiceExtensions
    {
        public static void AddProyectModule(this IServiceCollection Services)
        {

            Services.AddScoped<IProyectUseCase, ProyectUseCaseService>();
            Services.AddScoped<IProyectRepository, ProyectRepository>();


        }
    }
}
