using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigiWebApi.RoutesAndCRUD.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Context;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;


namespace DigiWebApi.RoutesAndCRUD.Repositories.Tests;


[TestClass()]
public class ClientRepositoryTests
{
	/// <summary>
	/// I want my Client number 1 to exist in the real local Database
	/// and have a filled Address of at least 12 characters.
	/// </summary>
	/// <returns></returns>
	[TestMethod()]
	[Timeout(3000)]
	public async Task GetClientByIdAsyncTest()
	{
		// Arrange
		ClientRepository clientRepository = new();
		Client? client = null;
		int id = 1;
		int addressFilled = 0;
		int minCharsForAddress = 12;

		// Act
		client = await clientRepository.GetClientByIdAsync(id);
		addressFilled = client?.Address.Length ?? -1;

		// Assert
		Assert.IsNotNull(client);
		Assert.IsTrue(addressFilled >= minCharsForAddress);
	}

	/// <summary>
	/// I want a random insert between 500 and 1000 included
	/// to fail and produce a DbUpdateException
	/// </summary>
	/// <returns></returns>
	[TestMethod()]
	[Timeout(3000)]
	public async Task AddClientAsyncTest()
	{
		// Arrange
		ClientRepository clientRepository = new();
		int randomId = RandomNumberGenerator.GetInt32(500, 1001);
		Client? client = new()
		{
			Id = randomId,
			Address = "l'adresse du Client",
			Name = "le nom du client",
		};
		Type exceptionType = typeof(Exception);
		bool hasFailed = false;

		// Act
		try
		{
			await clientRepository.AddClientAsync(client);
		}
		catch (Exception ex)
		{
			exceptionType = ex.GetType();
			hasFailed = true;
		}

		// Assert
		Assert.IsTrue(hasFailed);
		Assert.AreEqual(exceptionType, typeof(DbUpdateException));
	}
}