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


	[HttpPost]
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


	[HttpPost]
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


	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		List<Baguette> baguettes = await _baguetteService.GetAllAsync();

		if (baguettes.Count <= 0)
			return NotFound($"Aucune baguette en base de donnée !");
		else
			return Ok(baguettes);
	}


	[HttpGet]
	public async Task<IActionResult> GetAllDTO()
	{
		List<GetAllBaguetteDTO> baguettes = await _baguetteService.GetAllDTOAsync();

		if (baguettes.Count <= 0)
			return NotFound($"Aucune baguette en base de donnée !");
		else
			return Ok(baguettes);
	}


	[HttpGet("{name}")]
	public async Task<IActionResult> Search(string name)
	{
		List<Baguette> baguettes = await _baguetteService.GetAllLikeNameAsync(name);

		if (baguettes.Count <= 0)
			return NotFound($"Aucune baguette contenant le nom {name}.");
		else
			return Ok(baguettes);
	}

	// "{id}" pour passer en route
	// des parametres plus proprement genre GetById/12 pour l'element 12
	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		Baguette? baguette = await _baguetteService.GetByIdAsync(id);

		if (baguette is null)
			return NotFound($"Aucune baguette à l'identifiant {id}.");
		else
			return Ok(baguette);
	}


	[HttpPut]
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


	[HttpDelete("{id}")]
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