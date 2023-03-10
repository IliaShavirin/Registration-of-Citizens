namespace WebApi;

using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Middlewares;
using Services.Interfaces;
using Services.Services;

public class Startup
{
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                Configuration.GetConnectionString("MySqlServer"),
                new MySqlServerVersion(new Version(8, 0, 27))));

        services.AddSwaggerGen(opt =>
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Registration of citizens", Version = "v1" }));

        services.AddScoped<ICitizenService, CitizensService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionPage();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Registration of citizens v1");
            c.RoutePrefix = string.Empty;
        });

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseMiddleware<RequestValidationMiddleware>();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}