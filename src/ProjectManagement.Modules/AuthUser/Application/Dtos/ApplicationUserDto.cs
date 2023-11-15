

namespace ProjectManagement.Modules.AuthUser.Application.Dtos
{
    public record ApplicationUserDto(string Email, string Username, string Name, string LastName);

    public record RegisterResponseDto(string Email, string Username, string Token);
    public record RegisterRequestDto(string Email, string UserName,  string Password);

    public record LoginRequestDto(string Email, string Password);
    public record LoginResponseDto(string Email, string Username, string Token);
}
