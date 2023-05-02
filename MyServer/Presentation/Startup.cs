using Marten;
using Presentation.extensions;
using Weasel.Core;
namespace Presentation;
public class Startup
{
    private IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

    }
    public void ConfigureServices(IServiceCollection services)
    {
        var connectingString = Configuration.GetConnectionString("Marten");
        services.AddMarten(options =>
        {
             options.Connection(connectingString!);
             options.AutoCreateSchemaObjects = AutoCreate.All;
             options.Events.DatabaseSchemaName = "event_store";
        });
        services.AddControllers();
        services.AddSwaggerConfiguration();


    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (!env.IsDevelopment())
      {
          app.UseDeveloperExceptionPage();
      }
      app.UseCors(builder => builder.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod());
      
      app.UseSwaggerSetup();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
          endpoints.MapControllers();
      });
      
    }
}
