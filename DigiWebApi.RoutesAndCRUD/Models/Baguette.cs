using System.ComponentModel.DataAnnotations;

namespace DigiWebApi.RoutesAndCRUD.Models;


public class Baguette
{
	// EF handles Required, Auto Increment, and Primary Key automatically
	// for the property named "Id" with the DBMS
	public int Id { get; set; }

	[Required]
	[StringLength(30)]
	public string Name { get; set; } = "Baguette";

	[StringLength(100)]
	public string? Description { get; set; }

	[Required]
	[Range(0.0f, 5.0f)] // <!> WORKS IN BACK END, ONLY FRONT END IS PROTECTED??
	public float Price { get; set; }

	[Required]
	[StringLength(20)]
	public string Currency { get; set; } = "Euros";

	/// <summary>
	/// ORM ONLY --- 0, n
	/// </summary>
	public List<Client> Clients { get; set; } = new();
}
