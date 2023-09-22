using ProjectManagement.Modules.Commons.Application.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagement.Modules.Tasks.Application.Dtos
{
    public record TaskRequestDto( string Title, string Description, string State, string Priority, string Type, string AssignedUserId, int TagId);

    public record TaskResponseDto(int Id, string Title, string Description, string State, string Priority, 
                                  string Type, string AssignedUserId, string Proyect, int TagId, DateTime? CreatedAt, DateTime? UpdatedAt);


    public class TaskRequestParams : BaseRequestParams
    {

        public string? Search { get; set; }





    }


}
