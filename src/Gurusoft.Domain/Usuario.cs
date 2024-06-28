using System.ComponentModel.DataAnnotations;

namespace Gurusoft.Domain
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string User { get; set; }
        public int Password { get; set; }
        public ICollection<NumeroPrimo> NumeroPrimo { get; set; }
    }
}