using Gurusoft.Application.Dtos;
using Gurusoft.Application.Services.Interfaces;
using Gurusoft.Domain;
using MediatR;

namespace Gurusoft.Application.UseCases.NumerosPrimos
{
    public class ObtenerNumerosPrimos
    {
        public class ObtenerNumerosPrimosRequest : IRequest<Result<List<NumeroPrimoDto>>>
        {
        }

        public class Handler : IRequestHandler<ObtenerNumerosPrimosRequest, Result<List<NumeroPrimoDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<List<NumeroPrimoDto>>> Handle(ObtenerNumerosPrimosRequest request, CancellationToken cancellationToken)
            {
                var numerosPrimos = await _unitOfWork.NumeroPrimoRepository.ObtenerTodo();
                var numerosPrimosDto = new List<NumeroPrimoDto>();

                foreach (var item in numerosPrimos)
                {
                    var u = await _unitOfWork.UsuarioRepository.ObtenerPorId(item.UsuarioId);
                    var NumeroPrimoDto = new NumeroPrimoDto
                    {
                        Request = item.Request,
                        FechaRequest = item.FechaRequest,
                        Response = item.Response,
                        FechaResponse = item.FechaResponse,
                        UsuarioId = item.UsuarioId,
                        NombreUsuario = $"{ u.Nombres } { u.Apellidos }"
                    };

                    numerosPrimosDto.Add(NumeroPrimoDto);
                }

                return Result<List<NumeroPrimoDto>>.Success(numerosPrimosDto);
            }
        }
    }
}