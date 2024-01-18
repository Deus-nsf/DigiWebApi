using DigiWebApi.RoutesAndCRUD.Models;

using Microsoft.EntityFrameworkCore;


namespace DigiWebApi.RoutesAndCRUD.Context;


public class BakeryDbContext : DbContext
{
	// Entities/Models description
	public DbSet<Client> Clients { get; set; }
	public DbSet<Baguette> Baguettes { get; set; }


	public void OnConfiguringTestAccess(DbContextOptionsBuilder optionsBuilder)
	{
		OnConfiguring(optionsBuilder);
	}


	// DB description
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		//optionsBuilder.UseSqlServer
		//(
		//	"Data Source=(localdb)\\MSSQLLOCALDB;" +
		//	"Initial Catalog=Bakery;" +
		//	"Integrated Security=True"
		//);

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
		Client[] clients = new Client[]
		{
			new Client()
			{
				Id = 1,
				Name = "Marie Madelaine",
				Address = "432 avenue de la Gourmandise"
			},

			new Client()
			{
				Id = 2,
				Name = "Jean Michel",
				Address = "123 rue de la Jean-Michelerie"
			}
		};

		Baguette[] baguettes = new Baguette[]
		{
			new Baguette()
			{
				Id = 1,
				Name = "Pain complet",
				Description = "Du pain artisanal à la farine de blé complet.",
				Price = 2.50f,
				Currency = "Euros",
				//Clients = new List<Client>()
				//{
				//	clients[0],
				//	clients[1]
				//}
			},
			new Baguette()
			{
				Id = 2,
				Name = "Baguette tradition",
				Description = "Du pain artisanal à la farine blanche et plein de glucose !",
				Price = 1.20f,
				Currency = "Euros",
				//Clients = new List<Client>()
				//{ 
				//	clients[0],
				//	clients[1]
				//}
			},
			new Baguette()
			{
				Id = 3,
				Name = "Brioche",
				Description = "Fait majoritairement avec du beurre.",
				Price = 1.20f,
				Currency = "Euros",
				//Clients = new List<Client>()
				//{ 
				//	clients[0]
				//}
			},
			new Baguette()
			{
				Id = 4,
				Name = "Pain sans gluten",
				Description = "Ça existe au moins ?",
				Price = 4.50f,
				Currency = "Euros"
				// No Buyer
			}
		};

		modelBuilder.Entity<Client>().HasData(clients);
		modelBuilder.Entity<Baguette>().HasData(baguettes);

		base.OnModelCreating(modelBuilder);
	}
}
