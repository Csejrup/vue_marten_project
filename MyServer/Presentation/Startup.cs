using Marten;
using Presentation.extensions;
using Swashbuckle.AspNetCore.SwaggerUI;

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
        services.AddMarten(connectingString!);
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

/*
public class Startup
{
    private IConfiguration Configuration { get; }
    private string Env { get; set; }

    public Startup(IConfiguration configuration, string env)
    {
        Configuration = configuration;
        Env = env;
    }

    public void ConfigurationServices(IServiceCollection services)
    {
        Env = Environment.GetEnvironmentVariable("environment") ??
           throw new Exception("variable environment must be set; local_settings, local, production");
                                                    
       
        
       
       
        
       
       
       
                                                                                                
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        if (Env.Equals("local") || Env.Equals("local_settings"))
        {
            app.UseCors("Development");
        }
        else
        {
            app.UseCors("Production");
        }

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                options.OAuthConfigObject = new OAuthConfigObject
                {
                    ClientId = env.IsDevelopment() ? Configuration["FrontEgg:ClientId"] : "",
                    ClientSecret = env.IsDevelopment() ? Configuration["FrontEgg:ClientSecret"] : "",
                    AppName = "Swagger"
                };
            });
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                options.OAuthConfigObject = new OAuthConfigObject
                {
                    ClientId = !string.Equals(Env, "production") ? Configuration["FrontEgg:ClientId"] : "",
                    ClientSecret = !string.Equals(Env, "production") ? Configuration["FrontEgg:ClientSecret"] : "",
                    AppName = "Swagger"
                };
            });
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });                   
        app.UseEndpoints(endpoints =>                                                     
        {                                                                                 
            endpoints.MapControllers();                                                   
        });                                                                               
    }
}
*/