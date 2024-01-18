using System.ComponentModel.DataAnnotations;

namespace DigiWebApi.RoutesAndCRUD.Models;


public class Client
{
	// EF handles Required, Auto Increment, and Primary Key automatically
	// for the property named "Id" with the DBMS
	public int Id { get; set; }

	[Required]
	[StringLength(30)]
	public string Name { get; set; } = "Dupont";

	[Required]
	[StringLength(50)]
	public string Address { get; set; } = "123 rue de la Jean-Michelerie";

	/// <summary>
	/// ORM ONLY --- 0, n
	/// </summary>
	public List<Baguette> Baguettes { get; set; } = new();
}
