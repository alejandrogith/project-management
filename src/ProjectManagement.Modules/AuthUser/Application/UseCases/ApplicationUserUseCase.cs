using Mapster;
using ProjectManagement.Modules.AuthUser.Application.Dtos;
using ProjectManagement.Modules.AuthUser.Application.Ports.Input;
using ProjectManagement.Modules.AuthUser.Application.Ports.Output;
using ProjectManagement.Modules.AuthUser.Domain.Entities;
using ProjectManagement.Modules.Commons.Domain.Exceptions;

namespace ProjectManagement.Modules.AuthUser.Application.UseCases
{
    public class ApplicationUserUseCase : IApplicationUserUseCase
    {

        private readonly IApplicationUserRepository _appUserRepository;
        private readonly ITokenService _tokenService;

        public ApplicationUserUseCase(IApplicationUserRepository appUserRepository, ITokenService tokenService)
        {
            _appUserRepository = appUserRepository;
            _tokenService = tokenService;
        }

        public async Task<ApplicationUserDomain> FindUserByEmail(string Email)
        {
            var User= await _appUserRepository.FindUserByEmail(Email);

            return User;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequest)
        {

            var Exist = await _appUserRepository.Exist(loginRequest.Email);

            if (!Exist)
                throw new CustomNotFoundException($"The User with the email: {loginRequest.Email}  does not exist");


            var ApplicationUser = await _appUserRepository.Login(loginRequest.Email,loginRequest.Password);


            var Token = await _tokenService.GenerateToken(ApplicationUser);

            return new LoginResponseDto(ApplicationUser.Email,ApplicationUser.UserName, Token);
        }




        public async Task<RegisterResponseDto> Register( RegisterRequestDto registerRequest)
        {
            var Exist=  await _appUserRepository.Exist(registerRequest.Email);

            if (Exist)
                throw new CustomConflictException($"The User with the email: {registerRequest.Email} already exist");


            var ApplicationUser = registerRequest.Adapt<ApplicationUserDomain>();

            ApplicationUser = await _appUserRepository.Register(ApplicationUser,registerRequest.Password);

            var Token = await _tokenService.GenerateToken(ApplicationUser);

            return ApplicationUserMappers.MapToDto(ApplicationUser.Email, ApplicationUser.Email, Token);
        }
    }
}
