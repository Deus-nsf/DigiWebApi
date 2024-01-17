using DigiWebApi.RoutesAndCRUD.Context;
using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;


namespace DigiWebApi.RoutesAndCRUD.Repositories;


public class BaguetteRepository : IBaguetteRepository
{
	private readonly BakeryDbContext _dbContext = new();


	public async Task AddBaguetteAsync(Baguette baguette)
	{
		await _dbContext.Baguettes.AddAsync(baguette);
		await _dbContext.SaveChangesAsync();
	}


	public async Task<List<Baguette>> GetAllBaguettesAsync()
	{
		return await _dbContext.Baguettes.ToListAsync();
	}


	public async Task<List<Baguette>> GetAllBaguettesLikeNameAsync(string name)
	{
		return await _dbContext.Baguettes
			.Include(b => b.Clients)
			.Where(b => b.Name.Contains(name))
			.ToListAsync();
	}


	public async Task<Baguette?> GetBaguetteByIdAsync(int id)
	{
		return await _dbContext.Baguettes
			.Include(b => b.Clients)
			.FirstAsync(b => b.Id == id);
	}


	public async Task UpdateBaguetteAsync(Baguette baguette)
	{
		int updateResult = await _dbContext.Baguettes
			.Where(b => b.Id == baguette.Id)
			.ExecuteUpdateAsync(updates => updates				 
				.SetProperty(b => b.Description, baguette.Description)
				.SetProperty(b => b.Price, baguette.Price)
			);

		if (updateResult == 0)
		{
			throw new DbUpdateException(
				$"Element à l'identifiant {baguette.Id} non trouvé.");
		}
	}


	public async Task DeleteBaguetteAsync(int id)
	{
		int updateResult =
			await _dbContext.Baguettes.Where(b => b.Id == id)
			.ExecuteDeleteAsync();

		if (updateResult == 0)
		{
			throw new DbUpdateException(
				$"Element à l'identifiant {id} non trouvé.");
		}
	}
}
