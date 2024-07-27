using Serilog;
using Serilog.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog(config => config
    .Enrich.WithProperty("_EnrichedWithProperty", "PropertyValue")
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341"));

var app = builder.Build();

app.UseSerilogRequestLogging();

app.MapGet("/", (ILogger<Program> logger) =>
{
    using var logScope = logger.BeginScope("Scope with {ScopeValue}", "TestScopeValue");
    using var logContext = LogContext.PushProperty("_EnrichedFromLogContext", "PushProperty");

    logger.LogInformation(">>>> Sample log message from within the endpoint.");

    return new { response = "Logs were sent to the Console and to Seq." };
});

app.Run();
