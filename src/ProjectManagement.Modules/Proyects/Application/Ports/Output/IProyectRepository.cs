using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Proyects.Application.Dtos;
using ProjectManagement.Modules.Proyects.Domain.Entities;
using ProjectManagement.Modules.Tasks.Domain.Entities;

namespace ProjectManagement.Modules.Proyects.Application.Ports.Output
{
    public interface IProyectRepository
    {
        public Task<ProyectDomain> Save(ProyectDomain proyect);

        public Task<PaginatedDataDto<ProyectDomain>> FindAll(ProyectRequestParams proyectParams);



        public Task<ProyectDomain> FindById(int Id);

        public Task<ProyectDomain> Update(ProyectDomain proyect);


        public Task<ProyectDomain> Delete(ProyectDomain proyect);

    }
}
