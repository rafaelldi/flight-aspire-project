using FlightApi;
using GrpcFlights;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddGrpcClient<Flight.FlightClient>(it => it.Address = new Uri("http://worker"));

var app = builder.Build();

app.MapGet("/flights/{id}",
    async (string id, CancellationToken ct, Flight.FlightClient client) =>
    {
        var response = await client.GetFlightAsync(new FlightRequest { Id = id }, cancellationToken: ct);
        return TypedResults.Ok(new FlightDto(response.Id, response.From, response.To));
    }
);
app.MapPost("/flights",
    async (FlightDto flight, CancellationToken ct, Flight.FlightClient client) =>
    {
        var request = new CreateFlightRequest
        {
            Id = flight.Id,
            DepartureCity = flight.From,
            ArrivalCity = flight.To
        };
        var response = await client.CreateFlightAsync(request, cancellationToken: ct);
        return TypedResults.Created($"/flights/{response.Id}", flight);
    }
);
app.MapDefaultEndpoints();

app.Run();