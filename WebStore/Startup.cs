using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.BLL.Implementation;
using WebStore.BLL.Interfaces;

namespace WebStore
{
    public class Startup
    {
        /// <summary>
        /// Добавляем свойство для доступа к конфигурации
        /// </summary>
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEmployeeService, InMemoryEmployeeService>();

            //Добавляем сервисы, необходимые для mvc
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWelcomePage("/welcome");

            //Добавляем расширение для использования статических файлов, т.к. appsettings.json - это статический файл
            app.UseStaticFiles();

            //Добавляем обработку запросов в mvc-формате
            app.UseMvc(routes =>
            {
                //routes.MapRoute("catalogRoute", 
                //    template: "catalog/{section?}", 
                //    defaults: new { controller = "Home", action = "Shop" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}",
                    defaults: new { controller = "Home", action = "Index" }
                    );
            });
        }
    }
}
