using AutoMapper;
using Concessionaria.Contexts;
using Concessionaria.Repository;
using Concessionaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConcessionariaContext>(opts => 
    opts.UseSqlServer(builder.Configuration.GetConnectionString("ConcessionariaConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IMarcaRepository, MarcaRepository>();
builder.Services.AddTransient<ICarroRepository, CarroRepository>();

builder.Services.Configure<JsonSerializerSettings>(x => { 
    x.NullValueHandling = NullValueHandling.Ignore;
    x.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

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
