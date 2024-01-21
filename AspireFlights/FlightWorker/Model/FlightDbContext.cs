using Microsoft.EntityFrameworkCore;

namespace FlightWorker.Model;

public class FlightDbContext(DbContextOptions<FlightDbContext> options) : DbContext(options)
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<City> Cities { get; set; }
}