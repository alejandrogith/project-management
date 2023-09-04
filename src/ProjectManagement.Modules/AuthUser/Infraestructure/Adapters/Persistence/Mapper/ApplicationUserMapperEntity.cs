

using ProjectManagement.Modules.AuthUser.Application.Dtos;
using ProjectManagement.Modules.AuthUser.Domain.Entities;
using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Entity;

namespace ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Mapper
{
    public static class ApplicationUserMapperEntity
    {
        public static ApplicationUserDomain MapToDomain(ApplicationUser requestDto)
        {
            return new ApplicationUserDomain(requestDto.Email, requestDto.UserName, requestDto.Name, requestDto.LastName);
        }

        public static ApplicationUser MapToEntity(ApplicationUserDomain appUser)
        {
            return new ApplicationUser(appUser.Email, appUser.UserName, appUser.Name, appUser.LastName); 
        }

    }
}
