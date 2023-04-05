using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopRU.Persistence;
using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ShopRU.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices();
builder.Services.AddControllers(); //
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("ShopRU"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); //


app.UseEndpoints(endpoints => //
{
    endpoints.MapControllers();
});

app.Run();

