using Microsoft.EntityFrameworkCore;

namespace FlightWorker.Model;

public class FlightDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Flight> Flights => Set<Flight>();
    public DbSet<City> Cities => Set<City>();
}