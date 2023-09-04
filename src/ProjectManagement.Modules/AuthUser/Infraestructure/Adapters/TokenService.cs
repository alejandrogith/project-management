using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Modules.AuthUser.Application.Ports.Output;
using ProjectManagement.Modules.AuthUser.Domain.Entities;
using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagement.Modules.AuthUser.Infraestructure.Adapters
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        private readonly IConfiguration _config;

        private readonly UserManager<ApplicationUser> _userManager;

        public TokenService(IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:Key"]));
        }

        public async Task<string> GenerateToken(ApplicationUserDomain User)
        {
            var claims = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Email,User.Email),
                new Claim(JwtRegisteredClaimNames.Name,User.Name),
                new Claim(JwtRegisteredClaimNames.FamilyName,User.LastName),
                new Claim("Username",User.UserName)
            };




            var UserEntity =await _userManager.FindByEmailAsync(User.Email) ;

           var ROLES = await _userManager.GetRolesAsync(UserEntity);

            if (ROLES != null && ROLES.Count > 0)
            {
                ROLES.ToList().ForEach(role => {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                });
            }


            var credencials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenConfiguration = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credencials,
                Issuer = _config["JWTSettings:Issuer"],
                Audience = _config["JWTSettings:Audience"]

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfiguration);

            return tokenHandler.WriteToken(token);

        }


    }



}
