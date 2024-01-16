using System.ComponentModel.DataAnnotations;

namespace DigiWebApi.RoutesAndCRUD.DTOs;

public class GetAllBaguetteDTO
{
	public int Id { get; set; }

	[Required]
	[StringLength(30)]
	public string Name { get; set; } = "Baguette";

	[StringLength(100)]
	public string? Description { get; set; }

	[Required]
	[Range(0.0f, 5.0f)]
	public float Price { get; set; }
}
