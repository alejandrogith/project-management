using ProjectManagement.Modules.Commons.Application.Dtos;

namespace ProjectManagement.Modules.Proyects.Application.Dtos
{
    public record ProyectResponseDto(int Id, string Nombre, string Descripcion, DateTime? CreatedAt, DateTime? UpdatedAt);

    public record ProyectRequestDto(int Id,string Nombre, string Descripcion);

    public class ProyectRequestParams: BaseRequestParams {

        public string? Search { get; set; }


    }

  





}
