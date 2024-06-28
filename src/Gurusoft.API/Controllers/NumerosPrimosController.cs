using Gurusoft.Application.UseCases.NumerosPrimos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gurusoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NumerosPrimosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NumerosPrimosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerNumerosPrimos()
        {
            var response = await _mediator.Send(new ObtenerNumerosPrimos.ObtenerNumerosPrimosRequest());
            return Ok(response);
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