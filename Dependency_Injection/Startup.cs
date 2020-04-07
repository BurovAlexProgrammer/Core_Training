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
            services.AddTransient<ITimeSender, ShortTimeSender>();   //����� ������������ ���������� ���������� ��� �������� ����������
            services.AddTransient<TimeService>();   //����� ��������� ��� ������
        }

        //public void Configure(IApplicationBuilder app, TimeService timeService)
        //{
        //    app.Run(async (context) => {
        //        await context.Response.WriteAsync($"Current time: {timeService.ShowTime()}");
        //    });
        //}

        public void Configure(IApplicationBuilder app) //����� ������ ��������� �� ��������� ��������� ��� ���������� �������
        {
            app.Run(async (context) =>
            {//��� ������������� GetRequiredService<> ��� ���������� ����������� ������� ������� ����� ���������� ����������
                var ts = context.RequestServices.GetService<TimeService>();
                if (ts != null)
                    await context.Response.WriteAsync($"Current time: {ts.ShowTime()}");
            });
        }

    }
}
