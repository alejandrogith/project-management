using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Modules.Comments.Application.Dtos;
using ProjectManagement.Modules.Comments.Application.Ports.Input;
using ProjectManagement.Modules.Comments.Domain.Entities;
using ProjectManagement.Modules.Commons.Application.Dtos;
using System.Threading.Tasks;
using static ProjectManagement.WebApi.Middlewares.ExceptionHandlerMiddleware;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.WebApi.Controllers.Comment
{
    [Route("api/tasks/{taskId}/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {


        private readonly ICommentUseCase _commentUseCase;

        public CommentController(ICommentUseCase commentUseCase)
        {
            _commentUseCase = commentUseCase;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedDataDto<CommentDomain>>> FindAll([FromRoute] int taskId,[FromQuery] CommentRequestParams requestParams)
        {
            var Comments= await _commentUseCase.FindAll(taskId,requestParams);

            return Ok(Comments);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommentResponseDto>> FindById([FromRoute] int taskId, [FromRoute] int id)
        {

            var comment = await _commentUseCase.FindById(taskId, id);

            return  Ok(comment);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CommentResponseDto>> Save([FromRoute] int taskId,  [FromBody] CommentRequestDto reqComment)
        {
            var Comment =await _commentUseCase.Save(taskId,reqComment);
          

            return CreatedAtAction(nameof(Save), Comment);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CommentResponseDto>> Update([FromRoute] int taskId, [FromRoute] int id, [FromBody] CommentRequestDto reqComment)
        {
            var Comment = await _commentUseCase.Update(taskId,id,reqComment);

            return Ok(Comment);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete([FromRoute] int taskId, [FromRoute] int id)
        {
            await _commentUseCase.Delete(taskId,id);

            return NoContent();
        }



    }
}
