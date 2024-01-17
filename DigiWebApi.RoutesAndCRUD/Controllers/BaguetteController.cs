using System.Data.Common;

using DigiWebApi.RoutesAndCRUD.Context;
using DigiWebApi.RoutesAndCRUD.DTOs;
using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Repositories;
using DigiWebApi.RoutesAndCRUD.Services;
using DigiWebApi.RoutesAndCRUD.Services.Contracts;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DigiWebApi.RoutesAndCRUD.Controllers;


// [controller]/[action] pour pouvoir avoir les noms des routes automatiquement
[Route("api/[controller]/[action]")]
[ApiController]
public class BaguetteController : ControllerBase
{
	private readonly IBaguetteService _baguetteService;
	// Penser à l'injection de dépendance de l'auto mapper
	public BaguetteController(IBaguetteService baguetteService)
	{
		_baguetteService = baguetteService;
	}

	/// <summary>
	/// Create a new Baguette
	/// </summary>
	/// <param name="baguette"></param>
	/// <returns></returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Post(Baguette baguette)
	{
		try
		{
			await _baguetteService.AddAsync(baguette);
		}
		catch (Exception ex)
		{
			while (ex.InnerException is not null)
				ex = ex.InnerException;

			return BadRequest(ex.Message);
		}

		return Ok(baguette);
	}

	/// <summary>
	/// Create a new Baguette (simplified form)
	/// </summary>
	/// <param name="baguetteDto"></param>
	/// <returns></returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> PostDTO(PostBaguetteDTO baguetteDto)
	{
		try
		{
			await _baguetteService.AddDTOAsync(baguetteDto);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}

		return Ok(baguetteDto);
	}

	/// <summary>
	/// Get all the delicious Baguettes
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> GetAll()
	{
		List<Baguette> baguettes = await _baguetteService.GetAllAsync();

		if (baguettes.Count <= 0)
			return NoContent();
		//return NotFound($"Aucune baguette en base de donnée !");
		else
			return Ok(baguettes);
	}

	/// <summary>
	/// Get all the delicious Baguettes (simplified form)
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> GetAllDTO()
	{
		List<GetAllBaguettesDTO> baguettes = await _baguetteService.GetAllDTOAsync();

		if (baguettes.Count <= 0)
			return NoContent();
		//return NotFound($"Aucune baguette en base de donnée !");
		else
			return Ok(baguettes);
	}

	/// <summary>
	/// Search a Baguette with a criteria
	/// </summary>
	/// <param name="name">The criteria</param>
	/// <returns></returns>
	[HttpGet("{name}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Search(string name)
	{
		List<Baguette> baguettes = await _baguetteService.GetAllLikeNameAsync(name);

		if (baguettes.Count <= 0)
			return NotFound($"Aucune baguette contenant le nom {name}.");
		//return NoContent();
		else
			return Ok(baguettes);
	}

	// "{id}" pour passer en route
	// des parametres plus proprement genre GetById/12 pour l'element 12
	/// <summary>
	/// Find a specific Baguette
	/// </summary>
	/// <param name="id">Database identifier</param>
	/// <returns></returns>
	[HttpGet("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetById(int id)
	{
		Baguette? baguette = await _baguetteService.GetByIdAsync(id);

		if (baguette is null)
			return NotFound($"Aucune baguette à l'identifiant {id}.");
		//return NoContent();
		else
			return Ok(baguette);
	}

	/// <summary>
	/// Update a Baguette's main parameters
	/// </summary>
	/// <param name="baguette">(Only Description and Price will be updated)</param>
	/// <returns></returns>
	[HttpPut]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Put(Baguette baguette)
	{
		try
		{
			await _baguetteService.UpdateAsync(baguette);
		}
		catch (DbUpdateException ex)
		{
			return NotFound(ex.Message);
		}
		//catch (Exception ex)
		//{
		//	return BadRequest(ex.Message);
		//}

		return Ok($"La baguette à l'identifiant {baguette.Id} à été mise à jour.");
	}

	/// <summary>
	/// Delete a specific Baguette
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
			await _baguetteService.DeleteAsync(id);
		}
		catch (DbUpdateException ex)
		{
			return NotFound(ex.Message);
		}
		//catch (Exception ex)
		//{
		//	return BadRequest(ex.Message);
		//}

		return Ok($"La baguette à l'identifiant {id} à été supprimée.");
	}
}