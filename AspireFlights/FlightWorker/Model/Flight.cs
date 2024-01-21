namespace FlightWorker.Model;

public record Flight(string Id, string DepartureCity, DateTime DepartureTime, string ArrivalCity, DateTime ArrivalTime);