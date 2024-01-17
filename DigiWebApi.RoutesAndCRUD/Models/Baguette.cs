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
	[Range(0.0f, 5.0f)]
	public float Price { get; set; }

	[Required]
	[StringLength(20)]
	public string Currency { get; set; } = "Euros";

	/// <summary>
	/// Foreign Key --- 0, 1
	/// </summary>
	public int? ClientId { get; set; }
	// (must always set ORM linked entity to nullable for EF Core)
	/// <summary>
	/// ORM ONLY
	/// </summary>
	public Client? Client { get; set; }
}
