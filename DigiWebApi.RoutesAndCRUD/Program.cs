using DigiWebApi.RoutesAndCRUD.Context;
using DigiWebApi.RoutesAndCRUD.Repositories;
using DigiWebApi.RoutesAndCRUD.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at
// https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BakeryDbContext>();
builder.Services.AddScoped<BaguetteRepository>();
builder.Services.AddScoped<BaguetteService>();

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