using Purse.Application.Services;
using Purse.Domain.Entites;
using Purse.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Purse.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
