using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroAportes.Models;

public class Aportes
{
	[Key]
	public int AporteId { get; set; }

	[DataType(DataType.Date)]
	public DateTime Fecha { get; set; } = DateTime.Now;

	[Required(ErrorMessage = "Debe ingresar un nombre")]
	[RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "El nombre no debe contener números ni caracteres especiales")]
	public string Persona { get; set; }

	[Required(ErrorMessage = "Debe ingresar una observación")]
	public string Observacion { get; set; }

	[Range(1, int.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
	public decimal Monto { get; set; }
}
