using System;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;

namespace InmobiliariaDashboard.Server.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalDate"></param>
        /// <returns></returns>
        public static bool IsItWeekend(this DateTime originalDate)
        {
            return originalDate.DayOfWeek == DayOfWeek.Saturday || originalDate.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalDate"></param>
        /// <returns></returns>
        public static DateTime NextDayOfWeek(this DateTime originalDate)
        {
            var startDate = DateTime.Now > originalDate ? DateTime.Now : originalDate;
            var timePassed = startDate.TimeOfDay > originalDate.TimeOfDay;
            var addDays = timePassed ? 1 : 0;
            do
            {
                var nextDate = startDate.AddDays(addDays);
                if (originalDate.DayOfWeek == nextDate.DayOfWeek)
                    return new DateTime(nextDate.Year, nextDate.Month, nextDate.Day, originalDate.Hour,
                        originalDate.Minute, originalDate.Second, originalDate.Millisecond);
                addDays++;
            } while (true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="frequencyCode"></param>
        /// <returns></returns>
        public static DateTime NextOccurrence(this DateTime originalDate, string frequencyCode)
        {
            if (!string.IsNullOrEmpty(frequencyCode))
            {
                var reminderFrequency = BaseEnumeration.FromCode<ReminderFrequencyEnum>(frequencyCode);

                var startDate = DateTime.Now > originalDate ? DateTime.Now : originalDate;
                var timePassed = startDate.TimeOfDay > originalDate.TimeOfDay;
                var addDays = timePassed ? 1 : 0;

                if (Equals(reminderFrequency, ReminderFrequencyEnum.WorkingDays))
                {
                    var nextDate = startDate.AddDays(addDays);
                    var nextWorkingDate = new DateTime(nextDate.Year, nextDate.Month, nextDate.Day, originalDate.Hour,
                        originalDate.Minute, originalDate.Second, originalDate.Millisecond);
                    nextWorkingDate = nextWorkingDate.DayOfWeek switch
                    {
                        DayOfWeek.Saturday => nextWorkingDate.AddDays(2),
                        DayOfWeek.Sunday => nextWorkingDate.AddDays(1),
                        _ => nextWorkingDate
                    };
                    return nextWorkingDate;
                }

                if (Equals(reminderFrequency, ReminderFrequencyEnum.Daily))
                {
                    var nextDate = startDate.AddDays(addDays);
                    return new DateTime(nextDate.Year, nextDate.Month, nextDate.Day, originalDate.Hour,
                        originalDate.Minute, originalDate.Second, originalDate.Millisecond);
                }

                if (Equals(reminderFrequency, ReminderFrequencyEnum.Weekly))
                {
                    return originalDate.NextDayOfWeek();
                }

                var nextDay = startDate.AddDays(addDays);
                var dayPassed = nextDay.Day > originalDate.Day || nextDay.Day == 1 && addDays == 1;
                var addMonths = dayPassed ? 1 : 0;

                if (Equals(reminderFrequency, ReminderFrequencyEnum.Monthly))
                {
                    var nextDate = startDate.AddMonths(addMonths);
                    return new DateTime(nextDate.Year, nextDate.Month, originalDate.Day, originalDate.Hour,
                        originalDate.Minute, originalDate.Second, originalDate.Millisecond);
                }

                var nextMonth = nextDay.AddMonths(addMonths);
                var monthPassed = nextMonth.Month > originalDate.Month || nextMonth.Month == 1 && addMonths == 1;
                var addYears = monthPassed ? 1 : 0;

                if (Equals(reminderFrequency, ReminderFrequencyEnum.Annually))
                {
                    var nextDate = startDate.AddYears(addYears);
                    return new DateTime(nextDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour,
                        originalDate.Minute, originalDate.Second, originalDate.Millisecond);
                }
            }

            return originalDate;
        }
    }
}