using System.Reflection;
using System.Text.Json.Serialization;

using DigiWebApi.RoutesAndCRUD.Context;
using DigiWebApi.RoutesAndCRUD.DTOs;
using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Repositories;
using DigiWebApi.RoutesAndCRUD.Repositories.Contracts;
using DigiWebApi.RoutesAndCRUD.Services;
using DigiWebApi.RoutesAndCRUD.Services.Contracts;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at
// https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BakeryDbContext>
(
	options => options.UseSqlServer
	(
		"Data Source=(localdb)\\MSSQLLOCALDB;" +
		"Initial Catalog=Bakery;" +
		"Integrated Security=True"
	)
);
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IBaguetteRepository, BaguetteRepository>();
builder.Services.AddScoped<IBaguetteService, BaguetteService>();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bakery", Version = "v1" });
	// Set the comments path for the Swagger JSON and UI.
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	c.IncludeXmlComments(xmlPath);
});
builder.Services.AddControllers().AddJsonOptions(x =>
	x.JsonSerializerOptions.ReferenceHandler =
	ReferenceHandler.IgnoreCycles
);
//builder.Services.AddAutoMapper(o =>
//{
//	o.CreateMap<GetAllBaguettesDTO, Baguette>();
//	o.CreateMap<Baguette, GetAllBaguettesDTO>();
//});
//builder.Services.AddCors(options =>
//{
//	options.AddDefaultPolicy(builder =>
//	{
//		builder.WithOrigins("*")/*.AllowAnyHeader().AllowAnyMethod()*/;
//	});
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/*
	Projet ASP.NET Core API
	Entité + context => BDD
	Repository => en mode dossier

	API :
	GetAll
	GetById
	Search
	Post
	Put
	Delete

	Rajouter une entité pour faire du 1-n
	Faire un getById de votre entité avec un 
	include pour chargé la ou les autres entités avec
	Utiliser le ActionResult<T> a la place du 
	IActionResult et tester pour voir l'openApi
	Ajouter la génération XML et les /// sur les 
	méthodes et tester pour voir l'openApi
	Ajout des DTOs

	reste a faire :
	- donnees par defaut des tables de jointure (19/01/24)
	- tests unitaires des repositories en mode DB en RAM (19/01/24)
	- tests unitaires avec bouchonnage en utilisant le nuget Moq (19/01/24)
	- Tester diff entre IActionResult et ActionResult<T> avec Swagger
		-> fait (GetByIdReturnObject) mais pas trop compris la difference ?
 */