using AutoMapper;
using Concessionaria.Contexts;
using Concessionaria.Repository;
using Concessionaria.Repository.Interfaces;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConcessionariaContext>(opts => 
    opts.UseSqlServer(builder.Configuration.GetConnectionString("ConcessionariaConnection")));

builder.Services.Configure<JsonOptions>(opts => opts.SerializerOptions.DefaultIgnoreCondition 
    = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IMarcaRepository, MarcaRepository>();
builder.Services.AddTransient<ICarroRepository, CarroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var configuration = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
