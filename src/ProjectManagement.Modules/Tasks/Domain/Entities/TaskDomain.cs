using ProjectManagement.Modules.AuthUser.Domain.Entities;
using ProjectManagement.Modules.Commons.Infraestructure.Persistence;

namespace ProjectManagement.Modules.Tasks.Domain.Entities
{
    public class TaskDomain:BaseAuditableEntity
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }

        public string AssignedUser { get; set; }

        public string Proyect { get; set; }




        

    }
}
