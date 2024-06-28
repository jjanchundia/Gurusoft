using System.ComponentModel.DataAnnotations;

namespace Gurusoft.Domain
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public ICollection<NumeroPrimo> NumeroPrimo { get; set; }
    }
}