var hostBuilder = new HostBuilder()
    .ConfigureAppConfiguration(builder =>
    {
        builder
        .AddJsonFile("appsettings.json", false, true)
        .AddEnvironmentVariables(); //use all environment variables
    })
    .ConfigureLogging(builder =>
    {
        builder
        .SetMinimumLevel(LogLevel.Information) // from file
        .AddJsonConsole(options =>
        {
            options.TimestampFormat = "hh:mm:ss";
        });
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<Worker>();
    });

var host = hostBuilder.Build();

var configuration = host.Services.GetRequiredService<IConfiguration>(); //01:08

var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("test log");

await host.RunAsync();
