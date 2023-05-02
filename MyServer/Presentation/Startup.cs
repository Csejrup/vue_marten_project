using Application.Services;
using Domain.Repositories;
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
            // options.Projections.SelfAggregate<>()
        });
        services.AddControllers();
        services.AddSwaggerConfiguration();
        
        // Register repositories
        services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Register application services
        services.AddScoped<TaskItemService>();
        services.AddScoped<CommentService>();
        services.AddScoped<UserService>();
        
        
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
