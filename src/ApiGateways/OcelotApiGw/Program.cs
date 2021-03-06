using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//.WebHost.ConfigureLogging((hostingContext, loggingbuilder) =>
//{
//    loggingbuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
//    loggingbuilder.AddConsole();
//    loggingbuilder.AddDebug();
//});

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddOcelot();

var app = builder.Build();



app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();
