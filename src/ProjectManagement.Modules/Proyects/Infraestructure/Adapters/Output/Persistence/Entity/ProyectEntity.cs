

using ProjectManagement.Modules.Commons.Infraestructure.Persistence;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Entity;

namespace ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Entity
{
    public class ProyectEntity: BaseAuditableEntity
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<TaskEntity> Tasks { get; set; }

    }
}
