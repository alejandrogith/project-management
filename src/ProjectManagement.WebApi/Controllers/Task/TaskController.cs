﻿using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Tasks.Application.Dtos;
using ProjectManagement.Modules.Tasks.Application.ports.Input;
using ProjectManagement.Modules.Tasks.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectManagement.WebApi.Controllers.Task
{


    [Route("api/proyects/{proyectId?}/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        
        private readonly ITaskUseCase _taskUseCase;

        public TaskController(ITaskUseCase taskUseCase)
        {
            _taskUseCase = taskUseCase;
        }

        [SwaggerOperation("Find All Tasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<  PaginatedDataDto<TaskDomain> >> FindAll([FromRoute] int proyectId, [FromQuery] TaskRequestParams reqParams)
        {
            var Tasks = await _taskUseCase.FindAll(proyectId,reqParams);

            return Ok(Tasks);
        }



        [SwaggerOperation("Create a new Task")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TaskResponseDto>> Save([FromRoute] int proyectId,  [FromBody] TaskRequestDto taskRequest)
        {
            
            var Task = await _taskUseCase.Save(proyectId,taskRequest);

            return CreatedAtAction(nameof(Save), Task);
        }

        [SwaggerOperation("Find Tasks By Id")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponseDto>> FindById([FromRoute] int proyectId, [FromRoute] int id)
        {
            var Task = await _taskUseCase.FindById(proyectId, id);

            return Ok(Task);
        }


        [SwaggerOperation("Update a Task")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int proyectId, [FromRoute] int id, [FromBody] TaskRequestDto taskRequest)
        {
            await _taskUseCase.Update(proyectId,id, taskRequest);

            return NoContent();
        }

        [SwaggerOperation("Delete a Task")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int proyectId, int id)
        {
            
            await _taskUseCase.Delete(proyectId,id);

            return NoContent();
        }
    }
}
