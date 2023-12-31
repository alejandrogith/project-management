﻿using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Entity;
using ProjectManagement.Modules.Commons.Infraestructure.Persistence;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Entity;

namespace ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Entity
{
    public class CommentEntity:BaseAuditableEntity
    {


        public int Id { get; set; }
        public string Content { get; set; }

        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }

        public string  UserId { get; set; }
        public ApplicationUser CreatorUser { get; set; }


    }
}
