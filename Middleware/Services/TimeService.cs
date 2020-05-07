using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Middleware_And_Dependency_enjection
{
    //Самый правильный подход, это Middleware
    //TODO тема пока раскрыта не до конца, но суть видна
    public class TimeMiddleware
    {
        public TimeMiddleware(RequestDelegate next)
        {

        }

        public async Task InvokeAsync(HttpContext context, TimeService timeService)
        {
            await context.Response.WriteAsync(timeService.ShowTime());
        }
    }

    //Пример правильной реализации слабых связей для сервиса
    //В данном случае TimeService может быть определен как любой из классов, реализовавших интерфейс ITimeService
    public class TimeService
    {
        ITimeSender _sender;
        public TimeService(ITimeSender sender)
        {
            _sender = sender;
        }

        public string ShowTime()
        {
            return _sender.GetTime();
        }
    }


    public interface ITimeSender
    {
        string GetTime();
    }

    class FullTimeSender : ITimeSender
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("hh:mm:ss");
        }
    }

    class ShortTimeSender : ITimeSender
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("hh:mm");
        }
    }
}
