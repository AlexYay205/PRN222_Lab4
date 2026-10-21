using Vegan.Services.DuyLD;
using Vegan_WorkerService.DuyLD;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddEventLog(settings =>
{
    settings.SourceName = builder.Configuration["EventLog:SourceName"];
    settings.LogName = builder.Configuration["EventLog:LogName"];
});

builder.Services.AddHostedService<Worker>();

builder.Services.AddWindowsService(opt =>
{
    opt.ServiceName = "DuyLD_SE1905_WS";
});

builder.Services.AddScoped<IVeganPlaceServiceDuyLd, VeganPlaceServiceDuyLd>();

var host = builder.Build();
host.Run();
