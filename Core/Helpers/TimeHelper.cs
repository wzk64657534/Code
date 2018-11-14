using System;

namespace Core
{
    public sealed class TimeHelper
    {
        public static long GetTicks()
        {
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan ts = DateTime.Now.Subtract(start);
            return ts.Ticks;
        }
    }
}