using CrudNetCore5.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5
{
    //archivo inicializador
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //metodo ConfigureServices donde se hace la inyeccion de dependecias (para configurar el acceso a la db)
        //parquetes de nugets
        //tambien configuracion para de archivos json
        //y se puede acceder a ellos desde el controlador
        //metodo donde se inicializan las cosas que se utilizaran en la aplicacion
        public void ConfigureServices(IServiceCollection services)
        {
            //configuramos la cadena de conexion

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("conexion")));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //metodo Configure que permite acceder a las redirecciones, archivos estaticos (carpeta root (donde estan los archivos css, js, img, etc))
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //routing "rutas" como maneja las rutas en asp.net core mvc 
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern (configuracion de la ruta) por medio del controlador (Home) y el action (metodo )
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
