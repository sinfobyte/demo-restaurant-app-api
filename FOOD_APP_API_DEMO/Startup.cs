using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace FOOD_APP_API_DEMO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1", new OpenApiInfo {
                    Version = string.Empty,
                    Title = "Restaurant APP Demo API",
                    Description = $"## UI for testing demo API - {GetType().Assembly.GetName().Version.ToString()}",
                    Contact = new OpenApiContact
                    {
                        Name = "Sayed Shahidain",
                        Email = "mohd.shahidain@gmail.com",
                        Url = new Uri("https://github.com/almsoftware/demo-restaurant-app-api")
                    }
                });
                string filePath = Path.Combine(AppContext.BaseDirectory, "FOOD_APP_API_DEMO.xml");
                config.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseMvc();
            app.UseSwagger(x =>
            {
                x.SerializeAsV2 = true;
                x.PreSerializeFilters.Add((swaggerDoc, httpReq) => {
                    if (env.EnvironmentName == "Production")
                    {
                        string serverUrl = $"{httpReq.Scheme}://{httpReq.Headers["X-Forwarded-Host"]}";
                        swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = serverUrl } };
                    }
                });
            });
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("./swagger/v1/swagger.json", "API V1.0");
                x.RoutePrefix = string.Empty;
            });
        }
    }
}
