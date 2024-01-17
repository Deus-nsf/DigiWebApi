using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigiWebApi.RoutesAndCRUD.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiWebApi.RoutesAndCRUD.Models;

namespace DigiWebApi.RoutesAndCRUD.Repositories.Tests;

[TestClass()]
public class BaguetteRepositoryTests
{
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
		BaguetteRepository baguetteRepository = new();
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
	/// with the characters "pain" in their Name (case insensitive)
	/// </summary>
	/// <returns></returns>
	[TestMethod()]
	[Timeout(3000)]
	public async Task GetAllBaguettesLikeNameAsyncTest()
	{
		// Arrange
		BaguetteRepository baguetteRepository = new();
		List<Baguette> baguetteList = new();
		string searchCriteria = "pain";
		int minNumberOfRows = 3;
		int numberOfRowsFound = 0;

		// Act
		baguetteList = await baguetteRepository.GetAllBaguettesLikeNameAsync(searchCriteria);
		numberOfRowsFound = baguetteList.Count;

		// Assert
		Assert.IsTrue(numberOfRowsFound >= minNumberOfRows);
	}
}