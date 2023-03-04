using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AtechAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AtechAPI", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "AtechAPI", Version = "v2" });
            });

            services.AddVersionedApiExplorer(
               options =>
               {
                   options.AssumeDefaultVersionWhenUnspecified = true;
                   options.DefaultApiVersion = new ApiVersion(1, 0);
                   options.GroupNameFormat = "'v'VVV";
                   options.SubstituteApiVersionInUrl = true;


               });
            services.AddApiVersioning(
                            options =>
                            {
                                options.ReportApiVersions = true;
                                options.AssumeDefaultVersionWhenUnspecified = true;
                                options.DefaultApiVersion = new ApiVersion(1, 0);

                            })
                .AddMvc().AddNewtonsoftJson(
                  options =>
                  {
                      options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                  });

            services.AddAutofac();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AtechAPI v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "AtechAPI v2");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        // This method gets called by the runtime. Use this method to configure the AutoFac classes Registeration
        public void ConfigureContainer(ContainerBuilder builder)
        {

            // register all Serive interfaces with its service implementations in Service in AtechAPI.Services namespace         
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(AtechAPI)))
                .Where(x => x.Namespace != null && x.Namespace.StartsWith("AtechAPI.Services"))
                .As(t => t.GetInterfaces()).AsImplementedInterfaces();

        }
    }
}
