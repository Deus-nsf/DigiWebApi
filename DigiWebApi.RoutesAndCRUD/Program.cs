using DigiWebApi.RoutesAndCRUD.Context;
using DigiWebApi.RoutesAndCRUD.Repositories;
using DigiWebApi.RoutesAndCRUD.Repositories.Contracts;
using DigiWebApi.RoutesAndCRUD.Services;
using DigiWebApi.RoutesAndCRUD.Services.Contracts;


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

	DTO est optionnelle
 */