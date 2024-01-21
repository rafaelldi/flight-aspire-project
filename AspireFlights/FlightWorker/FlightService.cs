using FlightWorker.Model;
using Grpc.Core;
using GrpcFlights;
using Microsoft.EntityFrameworkCore;
using Flight = FlightWorker.Model.Flight;

namespace FlightWorker;

public class FlightService(FlightDbContext dbContext) : GrpcFlights.Flight.FlightBase
{
    public override async Task<FlightResponse> GetFlight(
        FlightRequest request,
        ServerCallContext context)
    {
        var flight = await dbContext.Flights.Where(flight => flight.Id == request.Id)
            .SingleOrDefaultAsync(context.CancellationToken);
        if (flight == null)
        {
            throw new ApplicationException();
        }

        var departureCity = await dbContext.Cities.Where(city => city.Id == flight.DepartureCity)
            .SingleOrDefaultAsync(context.CancellationToken);
        var arrivalCity = await dbContext.Cities.Where(city => city.Id == flight.ArrivalCity)
            .SingleOrDefaultAsync(context.CancellationToken);
        if (departureCity == null || arrivalCity == null)
        {
            throw new ApplicationException();
        }

        var response = new FlightResponse
        {
            Id = flight.Id,
            From = departureCity.Name,
            To = arrivalCity.Name
        };

        return response;
    }

    public override async Task<CreateFlightResponse> CreateFlight(
        CreateFlightRequest request,
        ServerCallContext context)
    {
        var flightModel = new Flight(
            request.Id,
            request.DepartureCity,
            DateTime.UtcNow,
            request.ArrivalCity,
            DateTime.UtcNow
        );

        await dbContext.Flights.AddAsync(flightModel, context.CancellationToken);

        await dbContext.SaveChangesAsync(context.CancellationToken);

        return new CreateFlightResponse { Id = request.Id };
    }
}