using DigiWebApi.RoutesAndCRUD.DTOs;
using DigiWebApi.RoutesAndCRUD.Models;


namespace DigiWebApi.RoutesAndCRUD.Services.Contracts;


public interface IClientService
{
	/// <summary>
	/// Post
	/// </summary>
	/// <param name="client"></param>
	/// <returns></returns>
	public Task AddAsync(Client client);

	/// <summary>
	/// GetAll
	/// </summary>
	/// <returns></returns>
	public Task<List<Client>> GetAllAsync();

	/// <summary>
	/// Search
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public Task<List<Client>> GetAllLikeNameAsync(string name);

	/// <summary>
	/// GetById
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public Task<Client?> GetByIdAsync(int id);

	/// <summary>
	/// Put
	/// </summary>
	/// <param name="client"></param>
	/// <returns></returns>
	public Task UpdateAsync(Client client);

	/// <summary>
	/// Delete
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public Task DeleteAsync(int id);
}
