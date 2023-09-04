using ProjectManagement.Modules.Proyects.Domain.Entities;
using ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Mapper
{
    public static class ProyectMapperPersistence
    {


        public static ProyectDomain MapToDomain(ProyectEntity project)
        {
            if (project == null)  return null;

            return new ProyectDomain
            {
                Id = project.Id,
                Nombre = project.Nombre,
                Descripcion = project.Descripción,
                CreatedAt = project.CreatedAt,
                UpdatedAt=project.UpdatedAt
                
            };
        }


        public static ProyectEntity MapToEntity(ProyectDomain project)
        {
            if (project == null) return null;

            return new ProyectEntity
            {
                Id = project.Id,
                Nombre = project.Nombre,
                Descripción = project.Descripcion,

            };
        }




    }
}
