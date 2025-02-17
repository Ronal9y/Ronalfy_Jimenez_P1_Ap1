using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ronalfy_Jimenez_P1_Ap1.Models
{
    public class Modelo
    {
        [Key]
        public int AporteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Este campo obligatorio")]
        public string? Persona { get; set; }
        [Required(ErrorMessage = "Este campo obligatorio")]
        public string? Observacion { get; set; }
        [Required(ErrorMessage = "Este campo obligatorio")]
        public decimal? Monto { get; set; }


    }
}
