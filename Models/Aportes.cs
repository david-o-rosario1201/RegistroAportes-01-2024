using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroAportes.Models;

public class Aportes
{
	[Key]
	public int AporteId { get; set; }

	[Column(TypeName = "Date")]
	public DateTime Fecha { get; set; }

	[Required(ErrorMessage = "Debe ingresar un nombre")]
	[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "El nombre no debe contener números ni carecteres especiales")]
	public string Persona { get; set; }

	[Required(ErrorMessage = "Debe ingresar una opservacion")]
	public string Observacion { get; set; }

	[Range(1, int.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
	public decimal Monto { get; set; }
}
