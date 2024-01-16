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
	/// GetAll
	/// </summary>
	/// <returns></returns>
	public Task<List<Baguette>> GetAllAsync();

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
