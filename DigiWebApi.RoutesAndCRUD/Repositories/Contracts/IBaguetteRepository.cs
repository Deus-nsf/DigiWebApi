using DigiWebApi.RoutesAndCRUD.Models;

using Microsoft.EntityFrameworkCore;


namespace DigiWebApi.RoutesAndCRUD.Repositories.Contracts;


public interface IBaguetteRepository
{
	public Task AddBaguetteAsync(Baguette baguette);

	public Task<List<Baguette>> GetAllBaguettesAsync();

	public Task<List<Baguette>> GetAllBaguettesLikeNameAsync(string name);

	public Task<Baguette?> GetBaguetteByIdAsync(int id);

	public Task UpdateBaguetteAsync(Baguette baguette);

	public Task DeleteBaguetteAsync(int id);
}
