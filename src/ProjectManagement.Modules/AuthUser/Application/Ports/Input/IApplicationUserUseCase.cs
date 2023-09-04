using ProjectManagement.Modules.AuthUser.Application.Dtos;
using ProjectManagement.Modules.AuthUser.Domain.Entities;

namespace ProjectManagement.Modules.AuthUser.Application.Ports.Input
{
    public interface IApplicationUserUseCase
    {
        public Task<RegisterResponseDto> Register(RegisterRequestDto registerRequest);
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequest);

        public Task<ApplicationUserDomain> FindUserByEmail(string Emain);
    }
}
