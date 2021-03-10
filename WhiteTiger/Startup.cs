using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WhiteTiger
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute(name: "Covid",
                pattern: "Covid",
                defaults: new { controller = "Home", action = "Covid" });

                endpoints.MapControllerRoute(name: "CarpetFloor",
                pattern: "CarpetFloor",
                defaults: new { controller = "Home", action = "CarpetFloor" });

                endpoints.MapControllerRoute(name: "Commercial",
                pattern: "Commercial",
                defaults: new { controller = "Home", action = "Commercial" });

                endpoints.MapControllerRoute(name: "Construction",
                pattern: "Construction",
                defaults: new { controller = "Home", action = "Construction" });

                endpoints.MapControllerRoute(name: "Contact",
                pattern: "Contact",
                defaults: new { controller = "Home", action = "Contact" });

                endpoints.MapControllerRoute(name: "IndustrialCommercial",
                pattern: "IndustrialCommercial",
                defaults: new { controller = "Home", action = "IndustrialCommercial" });

                endpoints.MapControllerRoute(name: "IndustrialConstruction",
                pattern: "IndustrialConstruction",
                defaults: new { controller = "Home", action = "IndustrialConstruction" });

                endpoints.MapControllerRoute(name: "SafeContractor",
                pattern: "SafeContractor",
                defaults: new { controller = "Home", action = "SafeContractor" });

                endpoints.MapControllerRoute(name: "Clients",
                pattern: "Clients",
                defaults: new { controller = "Home", action = "Clients" });

            });
        }
    }
}
