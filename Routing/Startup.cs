using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Routing
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Подключение сервиса маршрутизации
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            
            //Использование статичных маршрутов
            routeBuilder.MapRoute("Home", async context => {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<h1>Это домашняя страница</h1>");
            });

            routeBuilder.MapRoute("Home/Example", async context => {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<h1>Это еще один пример маршрута</h1>");
            });

            //Использование динамических маршрутов
            routeBuilder.MapRoute("{language}", async context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<h1>Определен маршрут как {language}</h1>");
            });
            //С использованием дополнительных параметров
            routeBuilder.MapRoute("{language}/{controller}/{action}/{*catchall}", async context =>
            {
                var s1 = context.GetRouteValue("language");
                var s2 = context.GetRouteValue("controller");
                var s3 = context.GetRouteValue("action");
                var s4 = context.GetRouteValue("catchall");
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<h1>Определен маршрут как {language}/{controller}/{action}/{*catchall}</h1>");
            });
            //

            app.UseRouter(routeBuilder.Build());

            app.Run(async context => { 
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<h1>Это та страница, которая отображается всегда, когда не найдена страницы в маршрутизации (страница по-умолчанию)</h1>"); 
            });
        }
    }
}
