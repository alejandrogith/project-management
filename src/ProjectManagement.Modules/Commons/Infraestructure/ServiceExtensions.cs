using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Modules.Commons.Infraestructure.Persistence;
using ProjectManagement.Modules.Proyects.Application.Ports.Input;
using ProjectManagement.Modules.Proyects.Application.ServicesUseCases;

namespace ProjectManagement.Modules.Commons.Infraestructure
{
    public static class ServiceExtensions
    {
        public static void AddCommonModule(this IServiceCollection Services,IConfiguration configuration)
        {


            Services.AddDbContext<ApplicationDbContext>(opciones =>
            opciones.UseSqlServer(configuration.GetConnectionString("ConexionSQL")));




        }



       

    }
}
