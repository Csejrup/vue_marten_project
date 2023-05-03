using Application.Services;
using Application.Services.ServiceInterfaces;
using Domain.Repositories;
using Domain.Repositories.InterfaceRepostories;
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
        
        var serializer = new Marten.Services.JsonNetSerializer
        {
            Casing = Casing.CamelCase
        };
        services.AddMarten(options =>
        {
            options.Connection(connectingString!);
            options.AutoCreateSchemaObjects = AutoCreate.All;
            options.Events.DatabaseSchemaName = "event_store";
            // options.DatabaseSchemaName ="taskManagementApi";
            // options.Projections.SelfAggregate<>()
            options.Serializer(serializer);

        }).OptimizeArtifactWorkflow().UseLightweightSessions();
        services.AddControllers();
        services.AddSwaggerConfiguration();
        services.AddEndpointsApiExplorer();
        services.AddMvc(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
        // Register repositories
        services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Register application services
        services.AddScoped<ITaskItemService, TaskItemService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IUserService, UserService>();
        
        
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
          app.UseDeveloperExceptionPage();
      }
      app.UseCors(builder => builder.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod());
      
      app.UseSwaggerSetup();
      app.UseRouting();
     // app.UseAuthentication();
     // app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
          endpoints.MapControllers();
      });
      
    }
}
