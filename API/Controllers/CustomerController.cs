using Application.CustomerCQRS.Commands.CreateCustomer;
using Application.CustomerCQRS.Queries.GetCustomer;
using Application.DTOs.CustomerDtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("create-customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            var command = _mapper.Map<CreateCustomerCommand>(dto);

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpGet("get-customer/{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var query = new GetCustomerQuery(id);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result.Data);
        }
    }
}
