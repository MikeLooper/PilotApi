using Microsoft.AspNetCore.Builder;
using Serilog;
using System;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.CreateBootstrapLogger();

try
{
	Log.Information("Starting server.");

	// app: create
	var webAppBuilder = WebApplication.CreateBuilder(args);

	webAppBuilder.Services.AddSerilog((services, lc) => lc
		.ReadFrom.Configuration(webAppBuilder.Configuration)
		.ReadFrom.Services(services));

	//webAppBuilder.Services.AddOpenApi();

	// app: build
	var webApp = webAppBuilder.Build();

	//webApp.MapOpenApi();
	//webApp.MapScalarApiReference();
	webApp.UseSerilogRequestLogging();
	webApp.UseHttpsRedirection();

	webApp.MapGet("/", () => "Hello from Serilog!");

	// app: run
	webApp.Run();
}
catch (Exception ex)
{
	Log.Fatal(ex, "Server terminated unexpectedly.");
}
finally
{
	Log.CloseAndFlush();
}
