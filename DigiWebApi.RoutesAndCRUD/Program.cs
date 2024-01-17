using DigiWebApi.RoutesAndCRUD.Context;
using DigiWebApi.RoutesAndCRUD.DTOs;
using DigiWebApi.RoutesAndCRUD.Models;
using DigiWebApi.RoutesAndCRUD.Repositories;
using DigiWebApi.RoutesAndCRUD.Repositories.Contracts;
using DigiWebApi.RoutesAndCRUD.Services;
using DigiWebApi.RoutesAndCRUD.Services.Contracts;

using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at
// https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BakeryDbContext>();
builder.Services.AddScoped<IBaguetteRepository, BaguetteRepository>();
builder.Services.AddScoped<IBaguetteService, BaguetteService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
//builder.Services.AddAutoMapper(o =>
//{
//	o.CreateMap<GetAllBaguetteDTO, Baguette>();
//	o.CreateMap<Baguette, GetAllBaguetteDTO>();
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
	- copier les commentaires et annotations en plus
	de CLientController vers BaguetteController
	- simuler references circulaires dans les modeles
 */