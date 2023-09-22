
using Mapster;
using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Commons.Domain.Exceptions;
using ProjectManagement.Modules.Proyects.Application.Dtos;
using ProjectManagement.Modules.Proyects.Application.Ports.Input;
using ProjectManagement.Modules.Proyects.Application.Ports.Output;
using ProjectManagement.Modules.Proyects.Domain.Entities;

namespace ProjectManagement.Modules.Proyects.Application.ServicesUseCases
{
    public class ProyectUseCaseService : IProyectUseCase
    {

        private readonly IProyectRepository _proyectRepository;



        public ProyectUseCaseService(IProyectRepository proyectRepository)
        {
            _proyectRepository = proyectRepository;
        }

        public async Task<ProyectResponseDto> Delete(int Id)
        {
            var Proyect = await _proyectRepository.FindById(Id);

            if (Proyect is null)
                throw new CustomNotFoundException($"The Proyect with the id: {Id} does not exist");

            await _proyectRepository.Delete(Proyect);

            return Proyect.Adapt<ProyectResponseDto>();
        }

        public async Task<PaginatedDataDto<ProyectDomain>> FindAll(ProyectRequestParams proyectParams)
        {
            return await  _proyectRepository.FindAll(proyectParams);
        }




        public async Task<ProyectResponseDto> FindById(int Id)
        {
            var Proyect = await _proyectRepository.FindById(Id);

            if (Proyect is null)
                throw new CustomNotFoundException($"The Proyect with the id: {Id} does not exist");

            return Proyect.Adapt<ProyectResponseDto>() ;
        }

        public async Task<ProyectResponseDto> Save(ProyectRequestDto proyectRequest)
        {
            var Proyect = proyectRequest.Adapt<ProyectDomain>() ;

            Proyect=await _proyectRepository.Save(Proyect);

            return Proyect.Adapt<ProyectResponseDto>();
        }



        public async Task<ProyectResponseDto> Update(int Id,ProyectRequestDto proyectRequest)
        {
            var Proyect = await _proyectRepository.FindById(Id);

            if (Proyect is null)
                throw new CustomNotFoundException($"The Proyect with the id: {Id} does not exist");


            Proyect = proyectRequest.Adapt<ProyectDomain>();

            Proyect = await _proyectRepository.Update(Proyect);

            return Proyect.Adapt<ProyectResponseDto>();
        }


    }
}
