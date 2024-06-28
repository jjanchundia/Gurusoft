using Gurusoft.Application.UseCases.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gurusoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //Uso del patron mediador - CQRS
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUsuario(CrearUsuario.CrearUsuarioCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login.LoginCommand command)
        {
            //Se retorna un UserDto con los datos del usuario logueado mas el Token
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
