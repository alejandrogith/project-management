using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Entity
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Task");

            builder.HasKey(e => e.Id);

            builder.Property(e=>e.AssignedUserId)
                .IsRequired(false);

            builder
              .HasOne(c => c.Proyect)
              .WithMany(c => c.Tasks)
              .HasForeignKey(c => c.ProyectId);

            builder
              .HasOne(c => c.AssignedUser)
              .WithMany(c => c.Tasks)
              .HasForeignKey(c => c.AssignedUserId);

            builder
              .HasOne(c => c.Tag)
              .WithMany(c => c.Tasks)
              .HasForeignKey(c => c.TagId)
              .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
