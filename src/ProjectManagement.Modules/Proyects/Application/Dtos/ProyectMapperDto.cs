using ProjectManagement.Modules.Proyects.Domain.Entities;

namespace ProjectManagement.Modules.Proyects.Application.Dtos
{
    public static class ProyectMapperDto
    {

        public static ProyectResponseDto MapToDto(ProyectDomain proyect)
        {
            if (proyect == null) return null;

            return new ProyectResponseDto
            (
                Id : proyect.Id,
                Nombre: proyect.Nombre,
                Descripción: proyect.Descripcion,
                CreatedAt: proyect.CreatedAt,
                UpdatedAt:proyect.UpdatedAt
            );
        }

        public static ProyectDomain MapToDomain(ProyectRequestDto proyectDto)
        {
            if (proyectDto == null) return null;

            return new ProyectDomain
            {
                Id=proyectDto.Id,
                Nombre = proyectDto.Nombre,
                Descripcion = proyectDto.Descripción,

            };
        }


    }
}
