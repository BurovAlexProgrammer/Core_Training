using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration_Builder.Services
{
    public interface ITimeService
    {
        string Send();
    }
    public class TimeServiceFull : ITimeService
    {
        public string Send()
        {
            return DateTime.Now.ToString("hh:mm:ss");
        }
    }

    public class TimeServiceHour : ITimeService
    {
        public string Send()
        {
            return DateTime.Now.Hour.ToString();
        }
    }
}
