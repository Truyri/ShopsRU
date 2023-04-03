using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopRU.Persistence;
using MediatR;
using ShopsRU.WebApi.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices();
builder.Services.AddControllers(); //
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());



builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var logger = app.Services.GetRequiredService<ILogger<Program>>();


app.UseHttpsRedirection();

app.UseRouting(); //


app.UseEndpoints(endpoints => //
{
    endpoints.MapControllers();
});

app.ConfigureExceptionHandler(logger);

app.Run();

