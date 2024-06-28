using Gurusoft.Application.Dtos;
using Gurusoft.Application.Services.Interfaces;
using Gurusoft.Domain;
using Gurusoft.Persistencia;
using MediatR;

namespace Gurusoft.Application.UseCases.Usuarios
{
    public class ConsultarListaUsuarios
    {
        public class ConsultarListaCommand : IRequest<Result<List<UsuarioDto>>>
        {
            public int UsuarioId { get; set; }
        }

        public class Handler : IRequestHandler<ConsultarListaCommand, Result<List<UsuarioDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<List<UsuarioDto>>> Handle(ConsultarListaCommand request, CancellationToken cancellationToken)
            {
                var users = await _unitOfWork.UsuarioRepository.ObtenerTodo(); 
                var usersDto = users.Select(u => new UsuarioDto
                {
                    IdUsuario = u.IdUsuario,
                    Nombres = u.Nombres,
                    Apellidos = u.Apellidos,
                    Username = u.User,
                    Password = u.Password,
                }).ToList();
                return Result<List<UsuarioDto>>.Success(usersDto);
            }
        }
    }
}