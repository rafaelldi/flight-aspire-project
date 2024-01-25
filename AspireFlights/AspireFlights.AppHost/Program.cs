var builder = DistributedApplication.CreateBuilder(args);

var worker = builder.AddProject<Projects.FlightWorker>("worker");

builder.AddProject<Projects.FlightApi>("api")
    .WithReference(worker);

builder.Build().Run();