using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
                    Version = "v1",
                    Title = "Restaurant APP Demo API",
                    Description = "## UI for testing demo API",
                    Contact = new OpenApiContact
                    {
                        Name = "Sayed Shahidain",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/shahidain"),
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
            app.UseMvc();
            app.UseSwagger(x =>
            {
                x.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1.0");
                x.RoutePrefix = string.Empty;
            });
        }
    }
}
