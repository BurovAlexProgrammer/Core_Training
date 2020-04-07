using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration_Builder
{
    //Comment
    public class TimeService
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("hh:mm");
        }
    }
}
