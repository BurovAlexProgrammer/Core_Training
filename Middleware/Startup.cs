using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace _3_Middleware
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITimeSender, ShortTimeSender>();   //����� ������������ ���������� ���������� ��� �������� ����������
            services.AddTransient<TimeService>();   //����� ��������� ��� ������
        }


        public void Configure(IApplicationBuilder app) //����� ������ ��������� �� ��������� ��������� ��� ���������� �������
        {
            app.UseMiddleware<TimeMiddleware>();
        }
    }
}
