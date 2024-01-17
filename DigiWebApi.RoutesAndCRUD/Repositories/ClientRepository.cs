using DigiWebApi.RoutesAndCRUD.Context;
using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;


namespace DigiWebApi.RoutesAndCRUD.Repositories;


public class ClientRepository : IClientRepository
{
	private readonly BakeryDbContext _dbContext = new();


	public async Task AddClientAsync(Client client)
	{
		await _dbContext.Clients.AddAsync(client);
		await _dbContext.SaveChangesAsync();
	}


	public async Task<List<Client>> GetAllClientsAsync()
	{
		return await _dbContext.Clients.ToListAsync();
	}


	public async Task<List<Client>> GetAllClientsLikeNameAsync(string name)
	{
		return await _dbContext.Clients
			.Include(c => c.Baguettes)
			.Where(c => c.Name.Contains(name))
			.ToListAsync();
	}

	public async Task<Client?> GetClientByIdAsync(int id)
	{
		return await _dbContext.Clients
			.Include(c => c.Baguettes)
			.FirstAsync(c => c.Id == id);
	}

	public async Task UpdateClientAsync(Client client)
	{
		int updateResult = await _dbContext.Clients
			.Where(b => b.Id == client.Id)
			.ExecuteUpdateAsync(updates => updates
				.SetProperty(c => c.Name, client.Name)
				.SetProperty(c => c.Address, client.Address)
			);

		if (updateResult == 0)
		{
			throw new DbUpdateException(
				$"Element à l'identifiant {client.Id} non trouvé.");
		}
	}


	public async Task DeleteClientAsync(int id)
	{
		int updateResult =
			await _dbContext.Clients.Where(b => b.Id == id)
			.ExecuteDeleteAsync();

		if (updateResult == 0)
		{
			throw new DbUpdateException(
				$"Element à l'identifiant {id} non trouvé.");
		}
	}
}
