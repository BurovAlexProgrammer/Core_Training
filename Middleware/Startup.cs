using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Middleware_And_Dependency_enjection
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
