using DigiWebApi.RoutesAndCRUD.DTOs;
using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Services.Contracts;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace DigiWebApi.RoutesAndCRUD.Controllers;


[Route("api/[controller]/[action]")]
[ApiController]
public class ClientController : ControllerBase
{
	private readonly IClientService _clientService;
	public ClientController(IClientService clientService)
	{
		_clientService = clientService;
	}

	/// <summary>
	/// Create a new Client
	/// </summary>
	/// <param name="client"></param>
	/// <returns></returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Post(Client client)
	{
		try
		{
			await _clientService.AddAsync(client);
		}
		catch (Exception ex)
		{
			while (ex.InnerException is not null)
				ex = ex.InnerException;

			return BadRequest(ex.Message);
		}

		return Ok(client);
	}

	/// <summary>
	/// Get all Clients
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> GetAll()
	{
		List<Client> clients = await _clientService.GetAllAsync();

		if (clients.Count <= 0)
			return NoContent();
		//return NotFound($"Aucun client en base de donnée !");
		else
			return Ok(clients);
	}

	/// <summary>
	/// Search a Client with a criteria
	/// </summary>
	/// <param name="name">The criteria</param>
	/// <returns></returns>
	[HttpGet("{name}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Search(string name)
	{
		List<Client> clients = await _clientService.GetAllLikeNameAsync(name);

		if (clients.Count <= 0)
			return NotFound($"Aucun client contenant le nom {name}.");
		//return NoContent();
		else
			return Ok(clients);
	}

	// "{id}" pour passer en route
	// des parametres plus proprement genre GetById/12 pour l'element 12
	/// <summary>
	/// Find a specific Client
	/// </summary>
	/// <param name="id">Database identifier</param>
	/// <returns></returns>
	[HttpGet("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetById(int id)
	{
		Client? client = await _clientService.GetByIdAsync(id);

		if (client is null)
			return NotFound($"Aucun client à l'identifiant {id}.");
		//return NoContent(); //NoContent is a success code! (204)
		else
			return Ok(client);
	}

	/// <summary>
	/// Find a specific Client and returns it as a raw object
	/// </summary>
	/// <param name="id">Database identifier</param>
	/// <returns></returns>
	[HttpGet("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<Client>> GetByIdReturnObject(int id)
	{
		Client? client = await _clientService.GetByIdAsync(id);

		if (client is null)
			return NotFound($"Aucun client à l'identifiant {id}.");
		//return NoContent();
		else
			return Ok(client);
	}

	/// <summary>
	/// Update a Client's main parameters
	/// </summary>
	/// <param name="client">(Only Name and Address will be updated)</param>
	/// <returns></returns>
	[HttpPut]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Put(Client client)
	{
		try
		{
			await _clientService.UpdateAsync(client);
		}
		catch (DbUpdateException ex)
		{
			return NotFound(ex.Message);
		}
		//catch (Exception ex)
		//{
		//	return BadRequest(ex.Message);
		//}

		return Ok($"Le client à l'identifiant {client.Id} à été mis à jour.");
	}

	/// <summary>
	/// Delete a specific Client
	/// </summary>
	/// <param name="id">Database identifier</param>
	/// <returns></returns>
	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{
			await _clientService.DeleteAsync(id);
		}
		catch (DbUpdateException ex)
		{
			return NotFound(ex.Message);
		}
		//catch (Exception ex)
		//{
		//	return BadRequest(ex.Message);
		//}

		return Ok($"Le client à l'identifiant {id} à été supprimé.");
	}
}
