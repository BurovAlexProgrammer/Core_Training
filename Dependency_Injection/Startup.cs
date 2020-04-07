using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dependency_Injection.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dependency_Injection
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITimeSender, ShortTimeSender>();   //Здесь определяется конкретная реализация для текущего интерфейса
            services.AddTransient<TimeService>();   //Здесь цепляется сам сервис
        }

        //public void Configure(IApplicationBuilder app, TimeService timeService)
        //{
        //    app.Run(async (context) => {
        //        await context.Response.WriteAsync($"Current time: {timeService.ShowTime()}");
        //    });
        //}

        public void Configure(IApplicationBuilder app) //Такой способ позволяет не добавлять параметры при добавлении сервиса
        {
            app.Run(async (context) =>
            {//При использовании GetRequiredService<> при отсутствии подключения нужного сервиса будет вызываться исключение
                var ts = context.RequestServices.GetService<TimeService>();
                if (ts != null)
                    await context.Response.WriteAsync($"Current time: {ts.ShowTime()}");
            });
        }

    }
}
