using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Modules.AuthUser.Application.Ports.Input;
using ProjectManagement.Modules.AuthUser.Application.Ports.Output;
using ProjectManagement.Modules.AuthUser.Application.UseCases;
using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters;
using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Entity;
using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Repository;
using ProjectManagement.Modules.Commons.Infraestructure.Persistence;
using System.Text;

namespace ProjectManagement.Modules.AuthUser.Infraestructure
{
    public static class ServiceExtensions
    {
        public static void AddAuthUserModule(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddScoped<IApplicationUserUseCase, ApplicationUserUseCase>();
            Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            Services.AddScoped<ITokenService, TokenService>();



            Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                };


            });


        }

    }
}
