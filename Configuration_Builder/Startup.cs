using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configuration_Builder.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Configuration_Builder
{
    public class Startup
    {
        //public void ConfigureServices(IServiceCollection services)
        //{
        //}
        public IServiceCollection appServices;
        public IConfiguration appConfiguration;


        public Startup()
        {
            //Здесь можно хранить глобаные конфигурации
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(new Dictionary<string, string> {
                { "Your global value", "what" },
                { "you want", "to keep" },
                { "key1", "val1"},
                { "key2", "val2" }
            });
            appConfiguration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TimeService>(); //Добавляет кастомный сервис в коллекцию сервисов
            services.AddTransient<ITimeService, TimeServiceFull>(); //Инъекция зависимости с более слабой связью (более правильный метод, в след. примере абсолютно правильный вариант)
            appServices = services; //Здесь можно получить все сервисы
        }

        public void Configure(IApplicationBuilder app, TimeService customService, ITimeService custorInjectedService)
        {
            app.Run(async (context) =>
            {

                await context.Response.WriteAsync($"v1: {appConfiguration["key1"]} v2:{appConfiguration["key2"]}");
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync($"Current time: {customService.GetTime()}");
                await context.Response.WriteAsync(Environment.NewLine);
                await context.Response.WriteAsync($"Current time: {custorInjectedService.Send()}");

                foreach (var service in appServices)
                {
                    //Проход по коллекции сервисов
                }

            });
        }


        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseRouting();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapGet("/", async context =>
        //        {
        //            await context.Response.WriteAsync("Hello World!");
        //        });
        //    });
        //}
    }
}
