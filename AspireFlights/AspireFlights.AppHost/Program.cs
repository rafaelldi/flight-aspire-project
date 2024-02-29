var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("postgres")
    .AddDatabase("flights");

var worker = builder.AddProject<Projects.FlightWorker>("worker")
    .WithReference(db);

builder.AddProject<Projects.FlightApi>("api")
    .WithReference(worker);

builder.Build().Run();