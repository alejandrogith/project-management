using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Modules.AuthUser.Application.Dtos;
using ProjectManagement.Modules.AuthUser.Application.Ports.Input;
using ProjectManagement.Modules.AuthUser.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using static ProjectManagement.WebApi.Middlewares.ExceptionHandlerMiddleware;

namespace ProjectManagement.WebApi.Controllers.AuthUser
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly IApplicationUserUseCase _appUserUseCase;

        public AuthUserController(IApplicationUserUseCase appUserUseCase)
        {
            _appUserUseCase = appUserUseCase;
        }



        [SwaggerOperation("Register a new User")]
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<RegisterResponseDto>> Register([FromBody] RegisterRequestDto registerRequest)
        {

            var RegisterData = await _appUserUseCase.Register(registerRequest);

            return CreatedAtAction(nameof(Register), RegisterData);
        }

        [SwaggerOperation("Login a new User")]
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto loginRequest)
        {
            var LoginData = await _appUserUseCase.Login(loginRequest);

            return Ok(LoginData);
        }



        [SwaggerOperation("Get User Details")]
        [HttpGet("useraccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationUserDomain>> GetUsuarioByEmail()
        {
            var Email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var UserInfo = await _appUserUseCase.FindUserByEmail(Email);

            return Ok(UserInfo);
        }










        }
}
