﻿using ProjectManagement.Modules.Commons.Infraestructure.Persistence;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Entity;

namespace ProjectManagement.Modules.Tags.Infraestructure.Adapters.Output.Persistence.Entity
{
    public class TagEntity:BaseAuditableEntity
    {


        public int Id { get; set; }

        public string Name { get; set; }


        public List<TaskEntity> Tasks { get; set; }


    }
}
