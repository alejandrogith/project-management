using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Entity
{
    public class ProyectEntityConfiguration : IEntityTypeConfiguration<ProyectEntity>
    {
        public void Configure(EntityTypeBuilder<ProyectEntity> builder)
        {

            builder.ToTable("Proyect");

            builder.HasKey(e => e.Id);

        }
    }
}
