 using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Proyects.Application.Dtos;
using ProjectManagement.Modules.Proyects.Application.Ports.Input;
using ProjectManagement.Modules.Proyects.Domain.Entities;
using ProjectManagement.Modules.Tasks.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using static ProjectManagement.WebApi.Middlewares.ExceptionHandlerMiddleware;

namespace ProjectManagement.WebApi.Controllers.Proyect
{
       
   
    [ApiController]
    [Route("api/proyects")]
    public class ProyectController : ControllerBase
    {

        private readonly IProyectUseCase _proyectUseCase;

        public ProyectController(IProyectUseCase proyectUseCase)
        {
            _proyectUseCase = proyectUseCase;
        }

        [SwaggerOperation("FindAll the Proyects")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaginatedDataDto<ProyectDomain>>> FindAll([FromQuery] ProyectRequestParams proyectParams)
        {

            var Results= await _proyectUseCase.FindAll(proyectParams);

            return Results;
        }

        [SwaggerOperation("Find Proyect by Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProyectResponseDto>> FindById([FromRoute] int id)
        {

            var Result = await _proyectUseCase.FindById(id);

            return Ok( Result );
        }





        [SwaggerOperation("Create a new Proyect")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async   Task<ActionResult<ProyectResponseDto>>   Post([FromBody] ProyectRequestDto proyect)
        {

          var Proyect =  await _proyectUseCase.Save(proyect);

            return Ok(Proyect);
        }


        [SwaggerOperation("Update a Proyect")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ProyectResponseDto> Put([FromRoute] int id, [FromBody] ProyectRequestDto proyect)
        {

            var Proyect = await _proyectUseCase.Update(id,proyect);

            return Proyect;
        }



        [SwaggerOperation("Delete a Proyect")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ProyectResponseDto> Delete([FromRoute] int id)
        {
            var Proyect =await _proyectUseCase.Delete(id);

            return Proyect;
        }








    }





    
}
