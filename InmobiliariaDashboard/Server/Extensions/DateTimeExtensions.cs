using System;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;

namespace InmobiliariaDashboard.Server.Extensions
{
    public static class DateTimeExtensions
    {
        // utils
        /// <summary>
        /// Determine if <paramref name="originalDate"></paramref>'s day of week is on weekend.
        /// </summary>
        /// <param name="originalDate"></param>
        /// <returns></returns>
        public static bool IsItWeekend(this DateTime originalDate)
        {
            return originalDate.DayOfWeek == DayOfWeek.Saturday || originalDate.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Get next day of week that matches <paramref name="originalDate"/> day of week.
        /// </summary>
        /// <param name="originalDate"></param>
        /// <returns></returns>
        public static DateTime NextDayOfWeek(this DateTime originalDate)
        {
            var stillDayOfWeek = DateTime.Now.TimeOfDay <= originalDate.TimeOfDay;
            if (stillDayOfWeek && originalDate.DayOfWeek == DateTime.Now.DayOfWeek)
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, originalDate.Hour,
                    originalDate.Minute, originalDate.Second);

            var i = 1;
            while (true)
            {
                var datePlus = DateTime.Now.AddDays(i);
                if (originalDate.DayOfWeek == datePlus.DayOfWeek)
                {
                    return new DateTime(datePlus.Year, datePlus.Month, datePlus.Day, originalDate.Hour,
                        originalDate.Minute, originalDate.Second);
                }

                i++;
            }
        }

        /// <summary>
        /// Get next reminder occurrence for <paramref name="originalDate"/> depending on <paramref name="frequencyCode"/>.
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="frequencyCode"></param>
        /// <returns></returns>
        // next occurrence
        public static DateTime NextOccurrence(this DateTime originalDate, string frequencyCode)
        {
            if (!string.IsNullOrEmpty(frequencyCode))
            {
                var reminderFrequency = BaseEnumeration.FromCode<ReminderFrequencyEnum>(frequencyCode);

                if (Equals(reminderFrequency, ReminderFrequencyEnum.WorkingDays))
                {
                    var nextDay = DateTime.Now.TimeOfDay <= originalDate.TimeOfDay
                        ? DateTime.Now.Day
                        : DateTime.Now.Day + 1;
                    var nextWorkingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, nextDay,
                        originalDate.Hour, originalDate.Minute, originalDate.Second);
                    nextWorkingDate = nextWorkingDate.DayOfWeek == DayOfWeek.Saturday ? nextWorkingDate.AddDays(2)
                        : nextWorkingDate.DayOfWeek == DayOfWeek.Sunday ? nextWorkingDate.AddDays(1)
                        : nextWorkingDate;
                    return nextWorkingDate;
                }

                if (Equals(reminderFrequency, ReminderFrequencyEnum.Daily))
                {
                    var nextDay = DateTime.Now.TimeOfDay <= originalDate.TimeOfDay
                        ? DateTime.Now.Day
                        : DateTime.Now.Day + 1;
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, nextDay, originalDate.Hour,
                        originalDate.Minute, originalDate.Second);
                }

                if (Equals(reminderFrequency, ReminderFrequencyEnum.Weekly))
                {
                    return originalDate.NextDayOfWeek();
                }

                if (Equals(reminderFrequency, ReminderFrequencyEnum.Monthly))
                {
                    var nextMonth = DateTime.Now.Day <= originalDate.Day ? DateTime.Now.Month : DateTime.Now.Month + 1;
                    return new DateTime(DateTime.Now.Year, nextMonth, originalDate.Day, originalDate.Hour,
                        originalDate.Minute, originalDate.Second);
                }

                if (Equals(reminderFrequency, ReminderFrequencyEnum.Annually))
                {
                    var nextYear = DateTime.Now.Month <= originalDate.Month ? DateTime.Now.Year : DateTime.Now.Year + 1;
                    return new DateTime(nextYear, originalDate.Month, originalDate.Day, originalDate.Hour,
                        originalDate.Minute, originalDate.Second);
                }
            }

            return DateTime.Now;
        }
    }
}