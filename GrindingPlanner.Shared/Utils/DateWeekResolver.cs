using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GrindingPlanner.Shared.Utils
{
    public class DateWeekResolver
    {
        public static int GetWeekNumber(DateTime date)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }

        public static int GetCurrentWeekNumber()
        {
            return GetWeekNumber(DateTime.Now);
        }

        public static DateTime GetFirstDayOfWeek(int year, int week)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;

            DateTime firstMonday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(jan1, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            if (firstWeek <= 1)
            {
                week -= 1;
            }

            return firstMonday.AddDays(week * 7);
        }

        public static DateTime GetLastDayOfWeek(int year, int week)
        {
            return GetFirstDayOfWeek(year, week).AddDays(6);
        }

        public static DateTime GetFirstDayOfCurrentWeek()
        {
            DateTime date = DateTime.Now;
            return GetFirstDayOfWeek(date.Year, GetWeekNumber(date));
        }
        public static DateTime GetLastDayOfCurrentWeek()
        {
            DateTime date = DateTime.Now;
            return GetLastDayOfWeek(date.Year, GetWeekNumber(date));
        }
    }
}
