using Gurusoft.Application.Dtos;
using Gurusoft.Application.Services.Interfaces;
using Gurusoft.Domain;
using MediatR;
using System.Text.Json;
using Gurosoft.Application.Utils;

namespace Gurusoft.Application.UseCases.NumerosPrimos
{
    public class CrearNumerosPrimos
    {
        public class CrearNumerosPrimosCommand : IRequest<Result<NumeroPrimoDto>>
        {
            public int NumeroInicio { get; set; }
            public int NumerosCalcular { get; set; }
            public int UsuarioId { get; set; }
        }

        public class Handler : IRequestHandler<CrearNumerosPrimosCommand, Result<NumeroPrimoDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<NumeroPrimoDto>> Handle(CrearNumerosPrimosCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var nombreUsuario = await _unitOfWork.NumeroPrimoRepository.ObtenerPorId(request.UsuarioId);

                    var fechaRequest = DateTime.Now;
                    var objectResquest = new
                    {
                        NumeroInicio = request.NumeroInicio,
                        NumerosCalcular = request.NumerosCalcular,
                    };

                    string jsonRequest = JsonSerializer.Serialize(objectResquest);

                    var numerosPrimos = LogicNumerosPrimos.CalcularNumerosPrimos(request.NumeroInicio, request.NumerosCalcular);

                    var fechaResponse = DateTime.Now;
                    var objectResponse = new
                    {
                        NumerosPrimos = numerosPrimos
                    };

                    string jsonResponse= JsonSerializer.Serialize(objectResponse);

                    var numeroPrimo = new NumeroPrimo
                    {
                        Request = jsonRequest,
                        FechaRequest = fechaRequest,
                        Response = jsonResponse,
                        FechaResponse = fechaResponse,
                        UsuarioId = request.UsuarioId
                    };

                    await _unitOfWork.NumeroPrimoRepository.Crear(numeroPrimo);
                    await _unitOfWork.SaveChangesAsync();

                    return Result<NumeroPrimoDto>.Success(new NumeroPrimoDto
                    {
                        Request = jsonRequest,
                        FechaRequest = fechaRequest,
                        Response = jsonResponse,
                        FechaResponse = fechaResponse,
                        UsuarioId = request.UsuarioId
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