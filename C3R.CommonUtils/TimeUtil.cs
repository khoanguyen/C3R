using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3R.CommonUtils
{
    public static class TimeUtil
    {
        public static DateTime Convert(DateTime dateTime, string sourceTzId, string destinateionTzId)
        {
            var srcTz = GetTimezone(sourceTzId);
            var desTz = GetTimezone(destinateionTzId);
            var srcTime = LocalDateTime.FromDateTime(dateTime).InZoneLeniently(srcTz);
            var desTimeZone = srcTime.ToInstant().InZone(desTz);
            return desTimeZone.ToDateTimeUnspecified();
        }

        public static DateTime FromLocal(DateTime dateTime, string toTz)
        {
            var localTz = DateTimeZoneProviders.Tzdb.GetSystemDefault().Id;
            return Convert(dateTime, localTz, toTz);
        }

        public static DateTime FromUTC(DateTime utcDateTime, string toTz)
        {
            return Convert(utcDateTime, "UTC", toTz);
        }

        public static TimeSpan GetOffset(string timezoneId)
        {
            return GetTimezone(timezoneId).GetUtcOffset(SystemClock.Instance.GetCurrentInstant()).ToTimeSpan();
        }
        public static TimeSpan GetOffsetAt(DateTime atDateTime, string timezoneId)
        {
            var tz = GetTimezone(timezoneId);
            var instant = LocalDateTime.FromDateTime(atDateTime).InZoneLeniently(tz).ToInstant();
            return GetTimezone(timezoneId).GetUtcOffset(instant).ToTimeSpan();
        }

        public static DateTime ToLocal(DateTime dateTime, string sourceTz)
        {
            var localTz = DateTimeZoneProviders.Tzdb.GetSystemDefault().Id;
            return Convert(dateTime, sourceTz, localTz);
        }

        public static DateTime ToUTC(DateTime dateTime, string fromTz)
        {
            return Convert(dateTime, fromTz, "UTC");
        }

        public static string GetLocalTimezoneBclId()
        {
            return DateTimeZoneProviders.Bcl.GetSystemDefault().Id;
        }

        public static string GetLocalTimezoneTzId()
        {
            return DateTimeZoneProviders.Tzdb.GetSystemDefault().Id;
        }

        private static DateTimeZone GetTimezone(string id)
        {
            DateTimeZone result = null;
            result = DateTimeZoneProviders.Tzdb.GetZoneOrNull(id);
            if (result == null) DateTimeZoneProviders.Bcl.GetZoneOrNull(id);
            if (result == null) throw new Exception("Timezone not found");

            return result;
        }
    }
}
