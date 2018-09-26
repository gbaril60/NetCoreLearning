using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardLib.Extensions
{
    public static class ValueExtensions
    {
        public static long Seconds(this ValueType source)
        {
            var secs = source.ConvertValue<long>();
            return secs;
        }
        public static long Minutes(this ValueType baseValue)
        {
            return baseValue.Seconds() * 60;
        }
        public static long Hours(this ValueType basevalue)
        {
            return basevalue.Minutes() * 60;
        }
        public static long Days(this ValueType baseValue)
        {
            return baseValue.Hours() * 24;
        }
        public static int Years(this ValueType baseValue)
        {
            return (int)baseValue.Days() * 365;
        }
        public static DateTime Ago(this long baseValue)
        {
            return DateTime.Now.AddSeconds(-1 * baseValue);
        }
        public static DateTime Before(this long baseValue, DateTime date)
        {
            return date.AddSeconds(-1 * baseValue);
        }
        public static DateTime FromNow(this long baseValue)
        {
            return DateTime.Now.AddSeconds(baseValue);
        }
        public static DateTime From(this long source, DateTime date)
        {
            return date.AddSeconds(source);
        }
        public static double Spans(this DateTime source, DateTime date)
        {
            var ts = date.Subtract(source);
            return ts.TotalSeconds;
        }
        public static double InDays(this double source)
        {
            return (source / (86400.0));
        }
        public static double InHours(this double source)
        {
            return (source / 3600.0);
        }
        public static double InMinutes(this double source)
        {
            return (source / 60.0);
        }
    }
}
