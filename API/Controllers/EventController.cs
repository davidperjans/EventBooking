using Application.DTOs.EventDtos;
using Application.Events.Commands.CreateEvent;
using Application.Events.Commands.DeleteEventById;
using Application.Events.Commands.UpdateEvent;
using Application.Events.Queries.GetAllEvents;
using Application.Events.Queries.GetEventById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EventController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("get-all-events")]
        public async Task<IActionResult> GetAllEvents()
        {
            var result = await _mediator.Send(new GetAllEventsQuery());
            return Ok(result);
        }

        [HttpGet("get-event/{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var result = await _mediator.Send(new GetEventByIdQuery(id));
            return Ok(result);
        }


        [HttpPost("create-event")]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto)
        {
            var command = _mapper.Map<CreateEventCommand>(dto);

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpPut("update-event/{id}")]
        public async Task<IActionResult> UpdateEventById(int id, [FromBody] UpdateEventDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            var command = _mapper.Map<UpdateEventCommand>(dto);

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpDelete("delete-event/{id}")]
        public async Task<IActionResult> DeleteEventById(int id)
        {
            var result = await _mediator.Send(new DeleteEventCommand(id));
            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }
    }
}
