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
                    return new DateTime(nextDate.Year, nextDate.Month, nextDate.Day, originalDate.Hour, originalDate.Minute, originalDate.Second);
                addDays++;
            } while (true);
        }

        public static DateTime NextOccurrence(this DateTime originalDate, string frequencyCode)
        {
            var startDate = DateTime.Now > originalDate ? DateTime.Now : originalDate;
            var timePassed = startDate.TimeOfDay > originalDate.TimeOfDay;
            var addDays = timePassed ? 1 : 0;

            if (!string.IsNullOrEmpty(frequencyCode))
            {
                var reminderFrequency = BaseEnumeration.FromCode<ReminderFrequencyEnum>(frequencyCode);

                if (Equals(reminderFrequency, ReminderFrequencyEnum.WorkingDays))
                {
                    var nextDay = startDate.AddDays(addDays);
                    var nextWorkingDate = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, originalDate.Hour,
                        originalDate.Minute, originalDate.Second);
                    nextWorkingDate = nextWorkingDate.DayOfWeek switch
                    {
                        DayOfWeek.Saturday => nextWorkingDate.AddDays(2),
                        DayOfWeek.Sunday => nextWorkingDate.AddDays(1),
                        _ => nextWorkingDate
                    };
                    return nextWorkingDate;
                }

                //if (Equals(reminderFrequency, ReminderFrequencyEnum.Daily))
                //{
                //    var nextDay = nowBeforeOriginalDate ? now : now.AddDays(1);
                //    return new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, originalDate.Hour,
                //        originalDate.Minute, originalDate.Second);
                //}

                //if (Equals(reminderFrequency, ReminderFrequencyEnum.Weekly))
                //{
                //    return originalDate.NextDayOfWeek();
                //}

                //if (Equals(reminderFrequency, ReminderFrequencyEnum.Monthly))
                //{
                //    var nextDay = nowBeforeOriginalDate ? now.Day : now.Day + 1;
                //    var nextMonth = nextDay <= originalDate.Day ? now.Month : now.Month + 1;
                //    var nextYear = now.Year;
                //    if (nextMonth == 13)
                //    {
                //        nextMonth = 1;
                //        nextYear = now.Year + 1;
                //    }

                //    return new DateTime(nextYear, nextMonth, originalDate.Day, originalDate.Hour,
                //        originalDate.Minute, originalDate.Second);
                //}

                //if (Equals(reminderFrequency, ReminderFrequencyEnum.Annually))
                //{
                //    var nextDay = nowBeforeOriginalDate ? now.Day : now.Day + 1;
                //    var nextMonth = nextDay <= originalDate.Day ? now.Month : now.Month + 1;
                //    var nextYear = nextMonth <= originalDate.Month ? now.Year : now.Year + 1;
                //    if (nextMonth == 13)
                //        nextYear += 1;
                //    return new DateTime(nextYear, originalDate.Month, originalDate.Day, originalDate.Hour,
                //        originalDate.Minute, originalDate.Second);
                //}
            }

            return now;
        }
    }
}