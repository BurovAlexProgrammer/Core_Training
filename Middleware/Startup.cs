using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Middleware_And_Dependency_enjection
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITimeSender, ShortTimeSender>();   //Здесь определяется конкретная реализация для текущего интерфейса
            services.AddTransient<TimeService>();   //Здесь цепляется сам сервис
        }


        public void Configure(IApplicationBuilder app) //Такой способ позволяет не добавлять параметры при добавлении сервиса
        {
            app.UseMiddleware<TimeMiddleware>();
        }
    }
}
