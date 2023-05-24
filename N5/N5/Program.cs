using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using N5.Controllers;
using Repository;
using RepositoryUsingEFinMVC.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<N5DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("N5Context") ?? throw new InvalidOperationException("Connection string 'N5Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsn5", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
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
app.UseCors("corsn5");


app.Run();
