﻿using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Tags.Application.Dtos;
using ProjectManagement.Modules.Tags.Application.Ports.Input;
using ProjectManagement.Modules.Tags.Domain.Entitites;
using Swashbuckle.AspNetCore.Annotations;
using static ProjectManagement.WebApi.Middlewares.ExceptionHandlerMiddleware;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.WebApi.Controllers.Tag
{
    [Route("api/tags")]
    [ApiController]
    public class TagController : ControllerBase
    {

        private readonly ITagUseCase _tagUseCase;

        public TagController(ITagUseCase tagUseCase)
        {
            _tagUseCase = tagUseCase;
        }


        [SwaggerOperation("Find All Tags")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedDataDto<TagDomain>>> FindAll([FromQuery] TagRequestParams requestParams)
        {
            var Tags = await _tagUseCase.FindAll(requestParams);

            return Ok(Tags);
        }

        [SwaggerOperation("Update a Tag")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromRoute] int id,TagRequestDto tagRequest)
        {
           await _tagUseCase.Update(id,tagRequest);

            return NoContent();
        }


        [SwaggerOperation("Create a new Tag")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TagResponseDto>> Save([FromBody] TagRequestDto tagRequest)
        {
            var Tag = await _tagUseCase.Save(tagRequest);

            return CreatedAtAction(nameof(Save), Tag);
        }

        [SwaggerOperation("Find Tag by Id")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TagResponseDto>> FindById([FromRoute] int id)
        {
            var Tag= await _tagUseCase.FindById(id);


            return Ok(Tag);
        }

        [SwaggerOperation("Delete a Tag")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _tagUseCase.Delete(id);

            return NoContent();
        }
    }
}
