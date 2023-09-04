using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Proyects.Application.Dtos;
using ProjectManagement.Modules.Proyects.Domain.Entities;
using ProjectManagement.Modules.Tasks.Domain.Entities;

namespace ProjectManagement.Modules.Proyects.Application.Ports.Input
{
    public interface IProyectUseCase
    {
        public Task<ProyectResponseDto> Save(ProyectRequestDto proyectRequest);


        public Task<PaginatedDataDto<ProyectDomain>> FindAll(ProyectRequestParams proyectParams);


        public Task<ProyectResponseDto> FindById(int Id);





        public Task<ProyectResponseDto> Update(int Id,ProyectRequestDto proyectRequest);

        public Task<ProyectResponseDto> Delete(int Id);
    }
}
