using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bank.model.repo;
using bank.config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace bankApi
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
            //allow angular to access data
            services.AddCors(options =>
                options.AddPolicy("AllowMyOrigin", builder =>
                    builder.WithOrigins("http://localhost:4200",
                                        "https://localhost4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                )
            );

            //get the right repository implementation
            var bankConfig = Configuration.GetSection("Bank:model");
            var bank = bankConfig.Get<MyConfig>();
            services.Configure<MyConfig>(bankConfig);

            BankRepositoryFactory.init(services, bank);


            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowMyOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
