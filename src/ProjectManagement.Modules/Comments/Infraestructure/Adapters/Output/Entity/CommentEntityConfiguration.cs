using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Entity
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {

            builder.ToTable("Comment");

            builder.HasKey(e => e.Id);

            builder
              .HasOne(c => c.Task)
              .WithMany(c => c.Comments)
              .HasForeignKey(c => c.TaskId);

            builder
              .HasOne(c => c.CreatorUser)
              .WithMany(c => c.Comments)
              .HasForeignKey(c => c.UserId)
              .OnDelete(DeleteBehavior.NoAction);



           
        }
    }
}
