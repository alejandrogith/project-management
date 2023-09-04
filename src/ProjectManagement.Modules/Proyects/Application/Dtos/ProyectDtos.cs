using ProjectManagement.Modules.Commons.Application.Dtos;

namespace ProjectManagement.Modules.Proyects.Application.Dtos
{
    public record ProyectResponseDto(int Id, string Nombre, string Descripción ,DateTime? CreatedAt, DateTime? UpdatedAt);

    public record ProyectRequestDto(int Id,string Nombre, string Descripción);

    public class ProyectRequestParams: BaseRequestParams {

        public string? Search { get; set; }


    }

  





}
