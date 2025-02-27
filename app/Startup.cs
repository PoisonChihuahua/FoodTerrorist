using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTerrorist.Controllers;
using FoodTerrorist.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FoodTerrorist {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers ();
            services.AddDbContext<FoodContext> (options =>
                    options.UseNpgsql (Configuration.GetConnectionString ("FoodDatabase")))
                .AddMvc ();
            services.AddSpaStaticFiles (x => { x.RootPath = "wwwroot/dist"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseRouting ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });

            app.UseSpaStaticFiles ();
            app.UseSpa (spa => { spa.Options.SourcePath = "wwwroot"; });
        }
    }
}