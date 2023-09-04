using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Modules.AuthUser.Application.Ports.Output;
using ProjectManagement.Modules.AuthUser.Domain.Entities;
using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Entity;
using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Errors;
using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Mapper;
using ProjectManagement.Modules.Commons.Infraestructure.Persistence;

namespace ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserRepository(ApplicationDbContext dbContext,
                                UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _signInManager = signInManager;
        }

        public async Task<bool> Exist(string Email)
        {
            return await _dbContext.ApplicationUser.Where(x=>x.Email==Email).CountAsync()>0;
        }

        public async Task<ApplicationUserDomain> FindUserByEmail(string Email)
        {
            var User=await _userManager.FindByEmailAsync(Email);

            return ApplicationUserMapperEntity.MapToDomain(User);
        }

        public async Task<ApplicationUserDomain> Login(string Email, string Password)
        {
            var User = await _userManager.FindByEmailAsync(Email);

            var Result = await _signInManager.CheckPasswordSignInAsync(User, Password, false);

            if (!Result.Succeeded)
                throw new CustomUnauthorizedException($"The user credentials is invalid");

            return ApplicationUserMapperEntity.MapToDomain(User);
        }

        public async Task<ApplicationUserDomain> Register(ApplicationUserDomain domain,string Password)
        {

           var ApplicationUser = ApplicationUserMapperEntity.MapToEntity(domain);

           var Result= await _userManager.CreateAsync(ApplicationUser, Password);

            if (!Result.Succeeded) {
                var Errors = Result.Errors.Select(x=>x.Description ).ToList();

                throw new CustomIdentityErrors(Errors);
            }
           
            return ApplicationUserMapperEntity.MapToDomain(ApplicationUser);
        }
    }
}
