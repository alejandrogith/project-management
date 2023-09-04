using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Modules.Comments.Application.Ports.Input;
using ProjectManagement.Modules.Comments.Application.Ports.Output;
using ProjectManagement.Modules.Comments.Application.UseCases;
using ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Repository;

namespace ProjectManagement.Modules.Comments.Infraestructure
{
    public static class ServiceExtensions
    {
        public static void AddCommentModule(this IServiceCollection Services)
        {
            Services.AddScoped<ICommentUseCase, CommentUseCase>();
            Services.AddScoped<ICommentRepository, CommentRepository>();
        }

    }
}
