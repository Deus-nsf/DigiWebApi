using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigiWebApi.RoutesAndCRUD.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiWebApi.RoutesAndCRUD.Models;
using Microsoft.EntityFrameworkCore;
using DigiWebApi.RoutesAndCRUD.Context;


namespace DigiWebApi.RoutesAndCRUD.Repositories.Tests;


[TestClass()]
public class BaguetteRepositoryTests
{
	private DbContextOptionsBuilder<BakeryDbContext> _optionsBuilder = 
		new DbContextOptionsBuilder<BakeryDbContext>().UseInMemoryDatabase("Bakery");

	private BakeryDbContext _dbContext;


	public BaguetteRepositoryTests()
	{
		_dbContext = new(_optionsBuilder.Options);
		_dbContext.Database.EnsureDeleted();
		_dbContext.Database.EnsureCreated();
	}
	 

	/// <summary>
	/// I want my Baguette number 7 to exist in the real local Database
	/// and have it's currency in Euros
	/// </summary>
	/// <returns></returns>
	[TestMethod()]
	[Timeout(3000)]
	public async Task GetBaguetteByIdAsyncTest()
	{
		// Arrange
		BaguetteRepository baguetteRepository = new(_dbContext);
		Baguette? baguette = null;
		int id = 7;
		string expectedCurrency = "Euros";

		// Act
		baguette = await baguetteRepository.GetBaguetteByIdAsync(id);
		string baguetteCurrency = baguette?.Currency ?? "NULL";

		// Assert
		Assert.IsNotNull(baguette);
		Assert.AreEqual(baguetteCurrency, expectedCurrency);
	}

	/// <summary>
	/// I want at least 3 Baguettes to exist in the real local Database
	/// with the characters "pain" in their Name (case sensitive)
	/// </summary>
	/// <returns></returns>
	[TestMethod()]
	[Timeout(3000)]
	public async Task GetAllBaguettesLikeNameAsyncTest()
	{
		// Arrange
		BaguetteRepository baguetteRepository = new(_dbContext);
		List<Baguette> baguetteList = new();
		string searchCriteria = "Pain";
		int minNumberOfRows = 3;
		int numberOfRowsFound = 0;

		// Act
		baguetteList = await baguetteRepository
							.GetAllBaguettesLikeNameAsync(searchCriteria);

		numberOfRowsFound = baguetteList.Count;

		// Assert
		Assert.IsTrue(numberOfRowsFound >= minNumberOfRows);
	}

	/// <summary>
	/// I want to test my parameters checks for an Insert
	/// </summary>
	/// <returns></returns>
	//[TestMethod()]
	//[Timeout(3000)]
	//public async Task AddBaguetteAsyncTest()
	//{
	//	// Arrange
	//	BakeryDbContext dbContext = new();

	//	// Needs nuget package Microsoft.EntityFrameworkCore.InMemory
	//	var optionsBuilder = new DbContextOptionsBuilder<BakeryDbContext>()
	//								.UseInMemoryDatabase("Bakery");

	//	dbContext.OnConfiguringTestAccess(optionsBuilder);

	//	// deletes in memory DB at each run
	//	await dbContext.Database.EnsureDeletedAsync();
	//	BaguetteRepository baguetteRepository = new();
	//	bool hasSucceded = false;

	//	// Act
	//	try
	//	{
	//		await baguetteRepository.AddBaguetteAsync
	//		(
	//			new Baguette
	//			{
	//				Id = 0, // EF Core will auto increment the Id if set to 0
	//				Name = "Baguette en RAM !",
	//				Description = "Cette baguette est faite de zeros et de uns !",
	//				Price = 3.2f,
	//				Currency = "Bytes",
	//				// No Clients
	//			}
	//		);

	//		hasSucceded = true;
	//	}
	//	catch (Exception ex)
	//	{
	//		while (ex.InnerException is not null)
	//			ex = ex.InnerException;

	//		await Console.Out.WriteLineAsync(ex.Message);
	//	}

	//	// Assert
	//	Assert.IsTrue(hasSucceded);
	//}
}