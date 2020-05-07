using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Middleware_And_Dependency_enjection
{
    //Это самый простой способ использования Middleware, со слабой связью
    //Остается только добавить в Startup -> ConfigureServices 'services.AddTransient<ITimeSender2, ShortTimeSender2>();'
    public class TimeMiddleware2        
    {
        private readonly RequestDelegate _next;         
        public TimeMiddleware2(RequestDelegate next)
        {
            _next = next;                               
        }

        public async Task InvokeAsync(HttpContext context, ITimeSender2 timeSender)
        {
            await context.Response.WriteAsync(timeSender.GetTime());
            await _next.Invoke(context); 
        }
    }

    public interface ITimeSender2
    {
        string GetTime();
    }

    class FullTimeSender2 : ITimeSender2
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("hh:mm:ss");
        }
    }

    class ShortTimeSender2 : ITimeSender2
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("hh:mm");
        }
    }
}
