using System.ComponentModel.DataAnnotations;

namespace Gurusoft.Domain
{
    public class NumeroPrimo
    {
        [Key]
        public int IdNumeroPrimo { get; set; }
        public string Request { get; set; }
        public DateTime FechaRequest { get; set; }
        public string Response { get; set; }
        public DateTime FechaResponse { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}