using ProjectManagement.Modules.Commons.Infraestructure.Persistence;

namespace ProjectManagement.Modules.Proyects.Domain.Entities
{
    public class ProyectDomain: BaseAuditableEntity
    {
  
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }



    }
}
