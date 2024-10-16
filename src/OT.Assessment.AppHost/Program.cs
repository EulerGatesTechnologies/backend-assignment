var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.OT_Assessment_Consumer>("ot-assessment-consumer");

builder.Build().Run();
