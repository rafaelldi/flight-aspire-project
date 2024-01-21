var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .AddDatabase("flights");

var worker = builder.AddProject<Projects.FlightWorker>("worker")
    .WithReference(postgres);

builder.AddProject<Projects.FlightApi>("api")
    .WithReference(worker);

builder.Build().Run();