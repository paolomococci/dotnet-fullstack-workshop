using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

using System.Collections.Generic;

using Cruises.Application;
using Cruises.Data;
using Cruises.Identity.Helpers;
using Cruises.Shared;
using Cruises.WebApi.Filters;
using Cruises.WebApi.Helpers;

namespace Cruises.WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddApplication();
      services.AddInfrastructureData();
      services.AddInfrastructureShared(Configuration);
      services.AddHttpContextAccessor();
      services.AddControllers();

      services.AddMemoryCache();

      services.AddControllersWithViews(
        options => options.Filters.Add(new ApiExceptionFilter())
      );

      services.Configure<ApiBehaviorOptions>(
        options => options.SuppressModelStateInvalidFilter = true
      );

      services.AddControllers();

      services.AddSwaggerGen(swaggerUIOptions =>
      {
        swaggerUIOptions.OperationFilter<SwaggerDefaultValues>();
        swaggerUIOptions.AddSecurityDefinition(
          "Bearer",
            new OpenApiSecurityScheme
            {
              Description = "JWT Authorization header using the Bearer scheme.",
              Name = "Authorization",
              In = ParameterLocation.Header,
              Type = SecuritySchemeType.Http,
              Scheme = "bearer"
            }
        );
        swaggerUIOptions.AddSecurityRequirement(
          new OpenApiSecurityRequirement
          {
            {
              new OpenApiSecurityScheme
              {
                Reference = new OpenApiReference
                {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
                }
              }, new List<string>()
            }
          }
        );
      });

      services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

      services.AddApiVersioning(config =>
      {
        config.DefaultApiVersion = new ApiVersion(1, 0);
        config.AssumeDefaultVersionWhenUnspecified = true;
        config.ReportApiVersions = true;
      });

      services.AddVersionedApiExplorer(options =>
      {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
      });
    }

    public void Configure(
      IApplicationBuilder app,
      IWebHostEnvironment env,
      IApiVersionDescriptionProvider provider
    )
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(swaggerUIOptions =>
        {
          foreach (var description in provider.ApiVersionDescriptions)
          {
            swaggerUIOptions.SwaggerEndpoint(
              $"/swagger/{description.GroupName}/swagger.json",
              description.GroupName.ToUpperInvariant()
            );
          }
        });
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseMiddleware<JwtMiddleware>();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
