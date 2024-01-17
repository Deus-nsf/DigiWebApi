using DigiWebApi.RoutesAndCRUD.DTOs;
using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Repositories.Contracts;
using DigiWebApi.RoutesAndCRUD.Services.Contracts;


namespace DigiWebApi.RoutesAndCRUD.Services;


public class ClientService : IClientService
{
	private readonly IClientRepository _clientRepository;
	public ClientService(IClientRepository clientRepository)
	{
		_clientRepository = clientRepository;
	}


	public async Task AddAsync(Client client)
	{
		await _clientRepository.AddClientAsync(client);
	}


	public async Task<List<Client>> GetAllAsync()
	{
		return await _clientRepository.GetAllClientsAsync();
	}


	public async Task<List<Client>> GetAllLikeNameAsync(string name)
	{
		return await _clientRepository.GetAllClientsLikeNameAsync(name);
	}


	public async Task<Client?> GetByIdAsync(int id)
	{
		return await _clientRepository.GetClientByIdAsync(id);
	}


	public async Task UpdateAsync(Client client)
	{
		await _clientRepository.UpdateClientAsync(client);
	}


	public async Task DeleteAsync(int id)
	{
		await _clientRepository.DeleteClientAsync(id);
	}
}
