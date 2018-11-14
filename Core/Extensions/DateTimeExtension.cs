using System;

namespace Core
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 转化为字符串，精确到天
        /// </summary>
        /// <param name="input">需要转化的时间对象</param>
        /// <returns>格式化时间字符串：yyyy-MM-dd</returns>
        public static string ToDateString(this DateTime input)
        {
            return input.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 转化为字符串，精确到秒
        /// </summary>
        /// <param name="input">需要转化的时间对象</param>
        /// <returns>格式化时间字符串：yyyy-MM-dd HH:mm:ss</returns>
        public static string ToTimeString(this DateTime input)
        {
            return input.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 转化为序号字符串，精确到毫秒
        /// </summary>
        /// <param name="input">需要转化的时间对象</param>
        /// <returns>格式化时间字符串：yyyyMMddHHmmssfff</returns>
        public static string ToMillisecondString(this DateTime input)
        {
            return input.ToString("yyyyMMddHHmmssfff");
        }

        /// <summary>
        /// 转化为数字型，精确到天
        /// </summary>
        /// <param name="input">需要转化的时间对象</param>
        /// <returns>格式化时间数值：yyyyMMdd</returns>
        public static int ToDateOfInt32(this DateTime input)
        {
            return input.ToString("yyyyMMdd").ToInt32();
        }

        /// <summary>
        /// 转化为时间戳
        /// 从1970-1-1开始到现在的秒数
        /// </summary>
        /// <param name="input">需要转化的时间对象</param>
        /// <returns>秒数</returns>
        public static long ToTimestamp(this DateTime input)
        {
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan ts = DateTime.Now.Subtract(start);
            return ts.Ticks;
        }

        /// <summary>
        /// 从时间戳构建一个时间对象
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <returns>时间对象</returns>
        public static DateTime FromTimestamp(int timestamp)
        {
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long time = long.Parse(timestamp + "0000000");
            TimeSpan now = new TimeSpan(time);

            return start.Add(now);
        }
    }
}