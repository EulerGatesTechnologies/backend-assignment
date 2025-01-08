var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.OT_Assessment_Consumer>("ot-assessment-consumer");

builder.AddProject<Projects.OT_Assessment_Tester>("ot-assessment-tester");

builder.AddProject<Projects.OT_Assessment_App>("ot-assessment-app");

builder.Build().Run();
