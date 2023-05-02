using System.Diagnostics;
using Azure.Identity;

namespace Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
                webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {})
                    .UseStartup<Startup>());
    }
}
/*
public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        
        // Reduce the insane chatter from DocumentDB.
        var defaultTrace = Type.GetType("Microsoft.Azure.Cosmos.Core.Trace.DefaultTrace,Microsoft.Azure.Cosmos.Direct");
        if (defaultTrace?.GetProperty("TraceSource")?.GetValue(null) is TraceSource traceSource)
        {
            traceSource.Switch.Level = SourceLevels.All;
            traceSource.Listeners.Clear();
        }

        var env = Environment.GetEnvironmentVariable("environment") ?? throw new Exception("variable environment must be set");
        if (string.Equals(env, "local_settings"))
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
        if (string.Equals(env, "local"))
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                        {
                            
                            var settings = config.Build();
                            config.AddAzureAppConfiguration(options =>
                            {
                                options.Connect(settings["ConnectionStrings:AppConfig"])
                                    .ConfigureKeyVault(kv =>
                                    {
                                        kv.SetCredential(new DefaultAzureCredential());
                                    });
                            });
                            
                        })
                        .UseStartup<Startup>());
        }

        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                        {
                            
                            var settings = config.Build();
                            config.AddAzureAppConfiguration(options =>
                            {
                                options.Connect(settings["ConnectionStrings:AppConfig"])
                                    .ConfigureKeyVault(kv =>
                                    {
                                        kv.SetCredential(new ManagedIdentityCredential(settings["Identity:ClientId"]));
                                    });
                            });
                            
                        })
                        .UseStartup<Startup>());
        }
    }
}
*/