using FlightWorker;
using FlightWorker.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddGrpc();
builder.AddNpgsqlDbContext<FlightDbContext>("flights");

var app = builder.Build();

app.MapGrpcService<FlightService>();
app.MapDefaultEndpoints();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FlightDbContext>();
    dbContext.Database.Migrate();
}

app.Run();