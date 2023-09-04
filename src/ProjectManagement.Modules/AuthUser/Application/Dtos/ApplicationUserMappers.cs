

using ProjectManagement.Modules.AuthUser.Domain.Entities;

namespace ProjectManagement.Modules.AuthUser.Application.Dtos
{
    public static class ApplicationUserMappers
    {
        public static RegisterResponseDto MapToDto(string Email,string Username,string Token) { 
        
            return new RegisterResponseDto(Email,Username,Token);
        }

        public static ApplicationUserDomain MapToDomain(RegisterRequestDto requestDto)
        {
            return new ApplicationUserDomain(requestDto.Email,requestDto.Username,requestDto.Name,requestDto.LastName);
        }


    }
}
