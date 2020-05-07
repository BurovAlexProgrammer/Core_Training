using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Middleware_
{
    //Самый правильный подход, это Middleware
    //Ему необходимы следующие ниже поля и методы
    public class TimeMiddleware        //Т.е. чтобы мидлвар заработал ему обязательно нужны эти 3 записи _next
    {
        private readonly RequestDelegate _next;         //Эта переменная хранит ссылку к следующему конвейеру
        public TimeMiddleware(RequestDelegate next)
        {
            _next = next;                               //Сама запись информации о следующем конвейере
        }

        public async Task InvokeAsync(HttpContext context, ITimeSender timeSender)
        {
            await context.Response.WriteAsync(timeSender.GetTime());
            //Блок исполнения единицы конвейера
            await _next.Invoke(context); //Сам переход ко след. конвейеру
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
