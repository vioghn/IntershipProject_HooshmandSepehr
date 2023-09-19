using Purse.Application.Services;
using Purse.Domain.Entites;
using Purse.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Purse.Infrastructure.Data;
using Purse.Application.Mapping;
using AutoMapper;

/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPurseService, PurseService>(); 
builder.Services.AddControllers();
builder.Services.AddDbContext<PurseDbContext>(options =>
{
    // Configure your database connection here
    options.UseSqlServer(@"Server=DESKTOP-CMR9S4V;Database=DemoDb;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
System.AggregateException: 'Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: Purse.Application.Contracts.IPurseService Lifetime: Scoped ImplementationType: Purse.Application.Services.PurseService': Unable to resolve service for type 'AutoMapper.IMapper' while attempting to activate 'Purse.Application.Services.PurseService'.)'

app.UseAuthorization();

app.MapControllers();

app.Run();
*/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPurseService, PurseService>();

// Add AutoMapper configuration
builder.Services.AddAutoMapper(typeof(PurseMappingProfile));

builder.Services.AddControllers();
builder.Services.AddDbContext<PurseDbContext>(options =>
{
    // Configure your database connection here
    options.UseSqlServer(@"Server=DESKTOP-CMR9S4V;Database=DemoDb;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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