using ProjectManagement.Modules.AuthUser.Domain.Entities;

namespace ProjectManagement.Modules.AuthUser.Application.Ports.Output
{
    public interface ITokenService
     {
        public Task<string> GenerateToken(ApplicationUserDomain usuario);
     }
}
