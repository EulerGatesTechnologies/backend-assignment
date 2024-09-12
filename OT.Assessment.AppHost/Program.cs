var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.OT_Assessment_Casino_Api>("ot-assessment-casino-api");

builder.AddProject<Projects.OT_Assessment_App>("ot-assessment-app");

builder.Build().Run();
