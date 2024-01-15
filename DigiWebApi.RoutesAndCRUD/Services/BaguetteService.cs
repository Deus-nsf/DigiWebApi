using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Repositories;

using Microsoft.EntityFrameworkCore;

namespace DigiWebApi.RoutesAndCRUD.Services;


public class BaguetteService
{
	private readonly BaguetteRepository _baguetteRepository;
	public BaguetteService(BaguetteRepository baguetteRepository)
	{
		_baguetteRepository = baguetteRepository;
	}

	/// <summary>
	/// Post
	/// </summary>
	/// <param name="baguette"></param>
	/// <returns></returns>
	public async Task AddBaguette(Baguette baguette)
	{
		await _baguetteRepository.AddBaguetteAsync(baguette);
	}

	/// <summary>
	/// GetAll
	/// </summary>
	/// <returns></returns>
	public async Task<List<Baguette>> GetAllBaguettes()
	{
		return await _baguetteRepository.GetAllBaguettesAsync();
	}

	/// <summary>
	/// Search
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public async Task<List<Baguette>> GetAllBaguettesLikeName(string name)
	{
		return await _baguetteRepository.GetAllBaguettesLikeNameAsync(name);
	}

	/// <summary>
	/// GetById
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task<Baguette?> GetBaguetteById(int id)
	{
		return await _baguetteRepository.GetBaguetteByIdAsync(id);
	}

	/// <summary>
	/// Put
	/// </summary>
	/// <param name="baguette"></param>
	/// <returns></returns>
	public async Task UpdateBaguette(Baguette baguette)
	{
		await _baguetteRepository.UpdateBaguetteAsync(baguette);
	}

	/// <summary>
	/// Delete
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task DeleteBaguette(int id)
	{
		await _baguetteRepository.DeleteBaguetteAsync(id);
	}
}
