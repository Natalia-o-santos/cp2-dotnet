using FluentValidation;
using FluentValidation.AspNetCore;
using FleetRental.Application;
using FleetRental.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Exibir Swagger sempre e na raiz
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FleetRental API v1");
    c.RoutePrefix = string.Empty; // abre em /
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
