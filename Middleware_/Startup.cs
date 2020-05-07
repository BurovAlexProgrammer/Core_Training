using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Middleware_
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITimeSender,FullTimeSender>();   //Цепляем сервис, который будем использовать в мидлваре
        }


        public void Configure(IApplicationBuilder app) //Такой способ позволяет не добавлять параметры при добавлении сервиса
        {
            app.UseMiddleware<TimeMiddleware>();
        }
    }
}
