using ProjectManagement.Modules.Commons.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Modules.Tags.Domain.Entitites
{
    public class TagDomain:BaseAuditableEntity
    {
        public TagDomain(int id, string name,DateTime? createdAt, DateTime? updateAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updateAt;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
