using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Repositories;
using DigiWebApi.RoutesAndCRUD.Repositories.Contracts;
using DigiWebApi.RoutesAndCRUD.Services.Contracts;

using Microsoft.EntityFrameworkCore;


namespace DigiWebApi.RoutesAndCRUD.Services;


public class BaguetteService : IBaguetteService
{
	private readonly IBaguetteRepository _baguetteRepository;
	public BaguetteService(IBaguetteRepository baguetteRepository)
	{
		_baguetteRepository = baguetteRepository;
	}


	public async Task AddAsync(Baguette baguette)
	{
		await _baguetteRepository.AddBaguetteAsync(baguette);
	}


	public async Task<List<Baguette>> GetAllAsync()
	{
		return await _baguetteRepository.GetAllBaguettesAsync();
	}


	public async Task<List<Baguette>> GetAllLikeNameAsync(string name)
	{
		return await _baguetteRepository.GetAllBaguettesLikeNameAsync(name);
	}


	public async Task<Baguette?> GetByIdAsync(int id)
	{
		return await _baguetteRepository.GetBaguetteByIdAsync(id);
	}


	public async Task UpdateAsync(Baguette baguette)
	{
		await _baguetteRepository.UpdateBaguetteAsync(baguette);
	}


	public async Task DeleteAsync(int id)
	{
		await _baguetteRepository.DeleteBaguetteAsync(id);
	}
}
