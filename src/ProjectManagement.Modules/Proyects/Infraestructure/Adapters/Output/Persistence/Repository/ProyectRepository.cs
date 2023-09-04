using Microsoft.EntityFrameworkCore;
using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Commons.Infraestructure.Persistence;

using ProjectManagement.Modules.Proyects.Application.Dtos;
using ProjectManagement.Modules.Proyects.Application.Ports.Output;
using ProjectManagement.Modules.Proyects.Domain.Entities;

using ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Entity;
using ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Mapper;
using ProjectManagement.Modules.Tasks.Domain.Entities;
using ProjectManagement.Modules.Tasks.Infraestructure.Adapters.Output.Persistence.Mapper;

namespace ProjectManagement.Modules.Proyects.Infraestructure.Adapters.Output.Persistence.Repository
{
    public class ProyectRepository : IProyectRepository
    {

        private readonly ApplicationDbContext _context;

        public ProyectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedDataDto<ProyectDomain>> FindAll(ProyectRequestParams proyectParams)
        {
            IQueryable<ProyectEntity> ProyectQuery = _context.ProyectEntity;

            if (!string.IsNullOrEmpty(proyectParams.Search))
            {

                ProyectQuery = ProyectQuery.Where(x =>
                x.Nombre.Contains(proyectParams.Search));

            }


            if (!string.IsNullOrEmpty(proyectParams.Sort))
            {
                ProyectQuery = proyectParams.Sort switch
                {
                    "nameAsc" => ProyectQuery.OrderBy(x => x.Id),
                    "nameDesc" => ProyectQuery.OrderByDescending(x => x.Id),
                    _ => ProyectQuery.OrderBy(x => x.Id)
                };
            }

            var Proyects = await ProyectQuery
                            .Skip(proyectParams.PageSize * (proyectParams.PageIndex - 1))
                            .Take(proyectParams.PageSize)
                            .Select(x => ProyectMapperPersistence.MapToDomain(x))
                            .AsNoTracking()
                            .ToListAsync();

            var count = await ProyectQuery.CountAsync();


            var Data = new PaginatedDataDto<ProyectDomain>(Proyects, proyectParams.PageIndex, proyectParams.PageSize, count);


            return Data;
        }

        public async Task<ProyectDomain> Save(ProyectDomain proyect)
        {
            var ProyectEntity = ProyectMapperPersistence.MapToEntity(proyect);
            await _context.ProyectEntity.AddAsync(ProyectEntity);
            await _context.SaveChangesAsync();

            return ProyectMapperPersistence.MapToDomain(ProyectEntity);
        }

        public async Task<ProyectDomain> Update(ProyectDomain proyect)
        {
            var Entity = ProyectMapperPersistence.MapToEntity(proyect);
            Entity.CreatedAt = await _context.ProyectEntity.Where(x=>x.Id==Entity.Id).Select(x => x.CreatedAt).FirstOrDefaultAsync(); 

            _context.ProyectEntity.Update(Entity);
            await _context.SaveChangesAsync();

            return ProyectMapperPersistence.MapToDomain(Entity);
        }

        public async Task<ProyectDomain> FindById(int Id)
        {
           var Proyect= await _context.ProyectEntity
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == Id);

            return ProyectMapperPersistence.MapToDomain(Proyect);
        }

        public async Task<ProyectDomain> Delete(ProyectDomain proyect)
        {
            var Entity = ProyectMapperPersistence.MapToEntity(proyect);
            
            _context.ProyectEntity.Remove(Entity);
           
            await _context.SaveChangesAsync();

            return ProyectMapperPersistence.MapToDomain(Entity);
        }


    }
}
