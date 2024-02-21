var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FreeCourse_Services_Order_API>("freecourse.services.order.api");

builder.AddProject<Projects.FreeCourse_Services_PhotoStock>("freecourse.services.photostock");

builder.AddProject<Projects.FreeCourse_Services_Discount>("freecourse.services.discount");

builder.AddProject<Projects.FreeCourse_Services_Catalog>("freecourse.services.catalog");

builder.AddProject<Projects.FreeCourse_services_basket>("freecourse.services.basket");

builder.Build().Run();
