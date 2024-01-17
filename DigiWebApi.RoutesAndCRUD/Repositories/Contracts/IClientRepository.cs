using DigiWebApi.RoutesAndCRUD.Models;

namespace DigiWebApi.RoutesAndCRUD.Repositories.Contracts;


public interface IClientRepository
{
	public Task AddClientAsync(Client client);

	public Task<List<Client>> GetAllClientsAsync();

	public Task<List<Client>> GetAllClientsLikeNameAsync(string name);

	public Task<Client?> GetClientByIdAsync(int id);

	public Task UpdateClientAsync(Client client);

	public Task DeleteClientAsync(int id);
}
