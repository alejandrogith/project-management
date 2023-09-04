using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Entity;
using ProjectManagement.Modules.Comments.Infraestructure.Adapters.Output.Entity;
using ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Entity;
using ProjectManagement.Modules.Tags.Infraestructure.Adapters.Output.Persistence.Entity;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Entity;
using System.Reflection;

namespace ProjectManagement.Modules.Commons.Infraestructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        public DbSet<ProyectEntity> ProyectEntity { get; set; }

        public DbSet<TaskEntity> TaskEntity { get; set; }


        public DbSet<CommentEntity> CommentEntity { get; set; }

        public DbSet<TagEntity> TagEntity { get; set; }


        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseAuditableEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }




}
