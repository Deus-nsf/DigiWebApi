using DigiWebApi.RoutesAndCRUD.Context;
using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Repositories;
using DigiWebApi.RoutesAndCRUD.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DigiWebApi.RoutesAndCRUD.Controllers;

// [controller]/[action] pour pouvoir avoir les noms des routes automatiquement
[Route("api/[controller]/[action]")]	
[ApiController]
public class BaguetteController : ControllerBase
{
	private readonly BaguetteService _baguetteService;
	public BaguetteController(BaguetteService baguetteService)
	{
		_baguetteService = baguetteService;
	}


	[HttpPost/*(nameof(Post))*/]
	public async Task<IActionResult> Post(Baguette baguette)
	{
		try
		{
			await _baguetteService.AddAsync(baguette);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
		
		return Ok(baguette);
	}


	[HttpGet/*(nameof(GetAll))*/]
	public async Task<IActionResult> GetAll()
	{
		List<Baguette> baguettes = await _baguetteService.GetAllAsync();

		if (baguettes.Count <= 0)
			return BadRequest($"Aucune baguette en base de donnée !");
		else
			return Ok(baguettes);
	}


	[HttpGet/*(nameof(Search))*/("{name}")]
	public async Task<IActionResult> Search(string name)
	{
		List<Baguette> baguettes = await _baguetteService.GetAllLikeNameAsync(name);

		if (baguettes.Count <= 0)
			return BadRequest($"Aucune baguette contenant le nom {name}.");
		else
			return Ok(baguettes);
	}

	// "{id}" pour passer en route
	// des parametres plus proprement genre GetById/12 pour l'element 12
	[HttpGet/*(nameof(GetById))*/("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		Baguette? baguette = await _baguetteService.GetByIdAsync(id);

		if (baguette is null)
			return BadRequest($"Aucune baguette à l'identifiant {id}.");
		else
			return Ok(baguette);
	}


	[HttpPut/*(nameof(Put))*/]
	public async Task<IActionResult> Put(Baguette baguette)
	{
		try
		{
			await _baguetteService.UpdateAsync(baguette);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
		
		return Ok($"La baguette à l'identifiant {baguette.Id} à été mise à jour.");
	}


	[HttpDelete/*(nameof(Delete))*/("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{
			await _baguetteService.DeleteAsync(id);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
		
		return Ok($"La baguette à l'identifiant {id} à été supprimée.");
	}
}