using DigiWebApi.RoutesAndCRUD.DTOs;
using DigiWebApi.RoutesAndCRUD.Models;


namespace DigiWebApi.RoutesAndCRUD.Services.Contracts;


public interface IBaguetteService
{
	/// <summary>
	/// Post
	/// </summary>
	/// <param name="baguette"></param>
	/// <returns></returns>
	public Task AddAsync(Baguette baguette);

	/// <summary>
	/// PostDTO
	/// </summary>
	/// <param name="postBaguetteDTO"></param>
	/// <returns></returns>
	public Task AddDTOAsync(PostBaguetteDTO postBaguetteDTO);

	/// <summary>
	/// GetAll
	/// </summary>
	/// <returns></returns>
	public Task<List<Baguette>> GetAllAsync();

	/// <summary>
	/// GetAllDTO
	/// </summary>
	/// <returns></returns>
	public Task<List<GetAllBaguetteDTO>> GetAllDTOAsync();

	/// <summary>
	/// Search
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public Task<List<Baguette>> GetAllLikeNameAsync(string name);

	/// <summary>
	/// GetById
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public Task<Baguette?> GetByIdAsync(int id);

	/// <summary>
	/// Put
	/// </summary>
	/// <param name="baguette"></param>
	/// <returns></returns>
	public Task UpdateAsync(Baguette baguette);

	/// <summary>
	/// Delete
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public Task DeleteAsync(int id);
}
