
namespace Gurusoft.Application.Dtos
{
    public class NumeroPrimoDto
    {
        public string Request { get; set; }
        public DateTime FechaRequest { get; set; }
        public string Response { get; set; }
        public DateTime FechaResponse { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
    }
}