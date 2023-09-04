using ProjectManagement.Modules.AuthUser.Domain.Entities;

namespace ProjectManagement.Modules.AuthUser.Application.Ports.Output
{
    public interface IApplicationUserRepository
    {
        public Task<ApplicationUserDomain> Register(ApplicationUserDomain domain, string Password);
        public Task<bool> Exist(string Email);


        public Task<ApplicationUserDomain> Login(string Email, string Password);

        public Task<ApplicationUserDomain> FindUserByEmail(string Email);

    }


}
