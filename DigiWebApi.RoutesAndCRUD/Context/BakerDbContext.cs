using DigiWebApi.RoutesAndCRUD.Models;

using Microsoft.EntityFrameworkCore;

namespace DigiWebApi.RoutesAndCRUD.Context;


public class BakeryDbContext : DbContext
{
	// Entities/Models description
	public DbSet<Baguette> Baguettes { get; set; }


	// DB description
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer
		(
			"Data Source=(localdb)\\MSSQLLOCALDB;" +
			"Initial Catalog=Bakery;" +
			"Integrated Security=True"
		);

#if DEBUG
		optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
#else
		optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.None);
#endif

		base.OnConfiguring(optionsBuilder);
	}


	// DB configuration, default/initial data
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		Baguette[] baguettes = new Baguette[]
		{
			new Baguette()
			{
				Id = 1,
				Name = "Pain complet",
				Description = "Du pain artisanal à la farine de blé complet.",
				Price = 2.50f,
				Currency = "Euros"
			},
			new Baguette()
			{
				Id = 2,
				Name = "Baguette tradition",
				Description = "Du pain artisanal à la farine blanche et plein de glucose !",
				Price = 1.20f,
				Currency = "Euros"
			},
			new Baguette()
			{
				Id = 3,
				Name = "Pain sans gluten",
				Description = "Ça existe au moins ?",
				Price = 4.50f,
				Currency = "Euros"
			}
		};

		modelBuilder.Entity<Baguette>().HasData(baguettes);

		base.OnModelCreating(modelBuilder);
	}
}
