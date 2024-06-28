using Gurusoft.Application.Dtos;
using Gurusoft.Application.Services.Interfaces;
using Gurusoft.Domain;
using MediatR;

namespace Gurusoft.Application.UseCases.Usuarios
{
    public class CrearUsuario
    {
        public class CrearUsuarioCommand : IRequest<Result<UsuarioDto>>
        {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<CrearUsuarioCommand, Result<UsuarioDto>>
        {
            //Se inyecta servicio UOW
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<UsuarioDto>> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var nuevo = new Usuario
                    {
                        Nombres = request.Nombres,
                        Apellidos = request.Apellidos,
                        User = request.User,
                        Password = request.Password,
                    };

                    //Uso del patron repository por medio de UOW
                    await _unitOfWork.UsuarioRepository.Crear(nuevo);
                    await _unitOfWork.SaveChangesAsync();

                    var ultimoIdInsertado = nuevo.IdUsuario;

                    return Result<UsuarioDto>.Success(new UsuarioDto
                    {
                        IdUsuario = ultimoIdInsertado,
                        Nombres = request.Nombres,
                        Apellidos = request.Apellidos,
                        Username = request.User,
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error", e.Message);
                    throw;
                }
            }
        }
    }
}