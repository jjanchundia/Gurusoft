using Gurosoft.Application.Utils;
using Gurusoft.Application.Dtos;
using Gurusoft.Application.Services.Interfaces;
using Gurusoft.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace Gurusoft.Application.UseCases.Usuarios
{
    public class Login
    {
        public class LoginCommand : IRequest<Result<UsuarioDto>>
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        public class Handler : IRequestHandler<LoginCommand, Result<UsuarioDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IConfiguration _config;

            public Handler(IUnitOfWork unitOfWork, IConfiguration config)
            {
                _unitOfWork = unitOfWork;
                _config = config;
            }

            public async Task<Result<UsuarioDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var filtros = new Dictionary<string, object>
                {
                    { "User", request.Username },
                    { "Password", request.Password }
                };

                var predicate = CrearPredicado(filtros);
                var usuario = await _unitOfWork.UsuarioRepository.Filtrar(predicate);

                string token2 = "";
                if (usuario == null)
                {
                    return Result<UsuarioDto>.Failure("No se encontró usuario!");
                }

                var response = Result<UsuarioDto>.Success(new UsuarioDto
                {
                    IdUsuario = usuario.IdUsuario,
                    Password = usuario.Password,
                    Username = usuario.User,
                });

                if (response.IsSuccess)
                {
                    var token = new LogicUsuarios(_config);
                    token2 = token.Token(response.Value.Username, response.Value.Password);
                }

                return Result<UsuarioDto>.Success(new UsuarioDto
                {
                    IdUsuario = usuario.IdUsuario,
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Password = usuario.Password,
                    Username = usuario.User,
                    Token = token2
                });
            }

            private Expression<Func<Usuario, bool>> CrearPredicado(Dictionary<string, object> filtros)
            {
                var parameter = Expression.Parameter(typeof(Usuario), "x");
                Expression exp = Expression.Constant(true);

                foreach (var filtro in filtros)
                {
                    var property = Expression.Property(parameter, filtro.Key);
                    var constant = Expression.Constant(filtro.Value);
                    var equality = Expression.Equal(property, constant);
                    exp = Expression.AndAlso(exp, equality);
                }

                return Expression.Lambda<Func<Usuario, bool>>(exp, parameter);
            }
        }
    }
}