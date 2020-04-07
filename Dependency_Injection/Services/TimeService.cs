using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_Injection.Services
{
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
