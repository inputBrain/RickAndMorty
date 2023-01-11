using Microsoft.AspNetCore;
using RickAndMorty.Host;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var webHost = BuildWebHost(args);
        await InitWebServices(webHost);
    }
    
    private static async Task<int> InitWebServices(IWebHost webHost)
    {
        await webHost.RunAsync();

        await webHost.StopAsync();
        Environment.Exit(0);
        return 0;
    }
        
    public static IWebHost BuildWebHost(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        return WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}