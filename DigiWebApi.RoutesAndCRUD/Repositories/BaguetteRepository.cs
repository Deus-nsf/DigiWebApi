using DigiWebApi.RoutesAndCRUD.Context;
using DigiWebApi.RoutesAndCRUD.Models;

using Microsoft.EntityFrameworkCore;


namespace DigiWebApi.RoutesAndCRUD.Repositories;


public class BaguetteRepository
{
	private readonly BakeryDbContext _context = new();


	public async Task AddBaguetteAsync(Baguette baguette)
	{
		await _context.Baguettes.AddAsync(baguette);
		await _context.SaveChangesAsync();
	}


	public async Task<List<Baguette>> GetAllBaguettesAsync()
	{
		return await _context.Baguettes.ToListAsync();
	}


	public async Task<List<Baguette>> GetAllBaguettesLikeNameAsync(string name)
	{
		return await _context.Baguettes.Where
			(b => b.Name.Contains(name))
			.ToListAsync();
	}


	public async Task<Baguette?> GetBaguetteByIdAsync(int id)
	{
		return await _context.Baguettes.FindAsync(id);
	}


	public async Task UpdateBaguetteAsync(Baguette baguette)
	{
		int updateResult = await _context.Baguettes.Where(b => b.Id == baguette.Id).ExecuteUpdateAsync
		(
			updates => updates.SetProperty(b => b.Description, baguette.Description)
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
		int updateResult = await _context.Baguettes.Where(b => b.Id == id).ExecuteDeleteAsync();

		if (updateResult == 0)
		{
			throw new DbUpdateException(
				$"Element à l'identifiant {id} non trouvé.");
		}
	}
}
