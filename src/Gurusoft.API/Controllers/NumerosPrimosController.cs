using Gurusoft.Application.UseCases.NumerosPrimos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gurusoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumerosPrimosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NumerosPrimosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<NumerosPrimosController>
        [HttpPost]
        public async Task<IActionResult> SolicitarPermiso(CrearNumerosPrimos.CrearNumerosPrimosCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}