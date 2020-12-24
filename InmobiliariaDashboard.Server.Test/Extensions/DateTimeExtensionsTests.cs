using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InmobiliariaDashboard.Server.Extensions;
using InmobiliariaDashboard.Shared.Enumerations;

namespace InmobiliariaDashboard.Server.Test.Extensions
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void IsItWeekend()
        {
            var dateFriday = new DateTime(2020, 12, 11);
            var dateSaturday = new DateTime(2020, 12, 12);
            var dateSunday = new DateTime(2020, 12, 13);
            var dateMonday = new DateTime(2020, 12, 14);
            Assert.AreEqual(false, dateFriday.IsItWeekend());
            Assert.AreEqual(true, dateSaturday.IsItWeekend());
            Assert.AreEqual(true, dateSunday.IsItWeekend());
            Assert.AreEqual(false, dateMonday.IsItWeekend());
        }

        [TestMethod]
        public void NextDayOfWeek()
        {
            // startDate = DateTime.Now, timePassed = false
            var originalDatePrev = DateTime.Now.AddDays(-7).AddSeconds(1);
            var originalDatePrevNext = originalDatePrev.NextDayOfWeek();
            Assert.AreEqual(originalDatePrev.DayOfWeek, originalDatePrevNext.DayOfWeek);
            Assert.AreEqual(originalDatePrev.AddDays(7).Date, originalDatePrevNext.Date);
            Assert.AreEqual(originalDatePrevNext.DayOfWeek, DateTime.Now.DayOfWeek);
            Assert.AreEqual(originalDatePrevNext.Date, DateTime.Now.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDatePrev2 = DateTime.Now.AddDays(-7).AddSeconds(-1);
            var originalDatePrevNext2 = originalDatePrev2.NextDayOfWeek();
            Assert.AreEqual(originalDatePrev2.DayOfWeek, originalDatePrevNext2.DayOfWeek);
            Assert.AreEqual(originalDatePrev2.AddDays(14).Date, originalDatePrevNext2.Date);
            Assert.AreEqual(originalDatePrevNext2.DayOfWeek, DateTime.Now.DayOfWeek);
            Assert.AreEqual(originalDatePrevNext2.Date, DateTime.Now.AddDays(7).Date);

            // startDate = originalDate, timePassed = false
            var originalDate = DateTime.Now.AddSeconds(1);
            var originalDateNext = originalDate.NextDayOfWeek();
            Assert.AreEqual(originalDate.DayOfWeek, originalDateNext.DayOfWeek);
            Assert.AreEqual(originalDate.Date, originalDateNext.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDate2 = DateTime.Now.AddSeconds(-1);
            var originalDateNext2 = originalDate2.NextDayOfWeek();
            Assert.AreEqual(originalDate2.DayOfWeek, originalDateNext2.DayOfWeek);
            Assert.AreEqual(originalDate2.AddDays(7).Date, originalDateNext2.Date);

            // startDate = originalDate, timePassed = false
            var originalDate3 = DateTime.Now.AddDays(10).AddSeconds(1);
            var originalDateNext3 = originalDate3.NextDayOfWeek();
            Assert.AreEqual(originalDate3.DayOfWeek, originalDateNext3.DayOfWeek);
            Assert.AreEqual(originalDate3.Date, originalDateNext3.Date);

            // startDate = originalDate, timePassed = true
            var originalDate4 = DateTime.Now.AddDays(10).AddSeconds(-1);
            var originalDateNext4 = originalDate4.NextDayOfWeek();
            Assert.AreEqual(originalDate4.DayOfWeek, originalDateNext4.DayOfWeek);
            Assert.AreEqual(originalDate4.Date, originalDateNext4.Date);
        }

        [TestMethod]
        public void NextOccurrenceWorkingDays()
        {
            var frequencyCode = ReminderFrequencyEnum.WorkingDays.Code;

            // startDate = DateTime.Now, timePassed = false
            var originalDatePrev = DateTime.Now.AddDays(-10).AddSeconds(1);
            var originalDatePrevNext = originalDatePrev.NextOccurrence(frequencyCode);
            Assert.AreEqual(DateTime.Now.Date, originalDatePrevNext.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDatePrev2 = DateTime.Now.AddDays(-10).AddSeconds(-1);
            var originalDatePrevNext2 = originalDatePrev2.NextOccurrence(frequencyCode);
            Assert.AreEqual(DateTime.Now.AddDays(1).Date, originalDatePrevNext2.Date);

            // startDate = originalDate, timePassed = false
            var originalDate = DateTime.Now.AddSeconds(1);
            var originalDateNext = originalDate.NextOccurrence(frequencyCode);
            Assert.AreEqual(DateTime.Now.Date, originalDateNext.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDate2 = DateTime.Now.AddSeconds(-1);
            var originalDateNext2 = originalDate2.NextOccurrence(frequencyCode);
            Assert.AreEqual(DateTime.Now.AddDays(1).Date, originalDateNext2.Date);

            // startDate = originalDate, timePassed = false
            var originalDate3 = DateTime.Now.AddDays(10).AddSeconds(1);
            var addDays = originalDate3.DayOfWeek switch
            {
                DayOfWeek.Saturday => 2,
                DayOfWeek.Sunday => 1,
                _ => 0
            };
            var originalDateNext3 = originalDate3.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate3.AddDays(addDays).Date, originalDateNext3.Date);

            // startDate = originalDate, timePassed = true
            var originalDate4 = DateTime.Now.AddDays(10).AddSeconds(-1);
            addDays = originalDate4.DayOfWeek switch
            {
                DayOfWeek.Saturday => 2,
                DayOfWeek.Sunday => 1,
                _ => 0
            };
            var originalDateNext4 = originalDate4.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate4.AddDays(addDays).Date, originalDateNext4.Date);
        }

        [TestMethod]
        public void NextOccurrenceDaily()
        {
            var frequencyCode = ReminderFrequencyEnum.Daily.Code;

            // startDate = DateTime.Now, timePassed = false
            var originalDatePrev = DateTime.Now.AddDays(-10).AddSeconds(1);
            var originalDatePrevNext = originalDatePrev.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDatePrev.AddDays(10).Date, originalDatePrevNext.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDatePrev2 = DateTime.Now.AddDays(-10).AddSeconds(-1);
            var originalDatePrevNext2 = originalDatePrev2.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDatePrev2.AddDays(11).Date, originalDatePrevNext2.Date);

            // startDate = originalDate, timePassed = false
            var originalDate = DateTime.Now.AddSeconds(1);
            var originalDateNext = originalDate.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate.Date, originalDateNext.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDate2 = DateTime.Now.AddSeconds(-1);
            var originalDateNext2 = originalDate2.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate2.AddDays(1).Date, originalDateNext2.Date);

            // startDate = originalDate, timePassed = false
            var originalDate3 = DateTime.Now.AddDays(10).AddSeconds(1);
            var originalDateNext3 = originalDate3.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate3.Date, originalDateNext3.Date);

            // startDate = originalDate, timePassed = true
            var originalDate4 = DateTime.Now.AddDays(10).AddSeconds(-1);
            var originalDateNext4 = originalDate4.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate4.Date, originalDateNext4.Date);
        }

        [TestMethod]
        public void NextOccurrenceWeekly()
        {
            var frequencyCode = ReminderFrequencyEnum.Weekly.Code;

            // startDate = DateTime.Now, timePassed = false
            var originalDatePrev = DateTime.Now.AddDays(-7).AddSeconds(1);
            var originalDatePrevNext = originalDatePrev.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDatePrev.DayOfWeek, originalDatePrevNext.DayOfWeek);
            Assert.AreEqual(originalDatePrev.AddDays(7).Date, originalDatePrevNext.Date);
            Assert.AreEqual(originalDatePrevNext.DayOfWeek, DateTime.Now.DayOfWeek);
            Assert.AreEqual(originalDatePrevNext.Date, DateTime.Now.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDatePrev2 = DateTime.Now.AddDays(-7).AddSeconds(-1);
            var originalDatePrevNext2 = originalDatePrev2.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDatePrev2.DayOfWeek, originalDatePrevNext2.DayOfWeek);
            Assert.AreEqual(originalDatePrev2.AddDays(14).Date, originalDatePrevNext2.Date);
            Assert.AreEqual(originalDatePrevNext2.DayOfWeek, DateTime.Now.DayOfWeek);
            Assert.AreEqual(originalDatePrevNext2.Date, DateTime.Now.AddDays(7).Date);

            // startDate = originalDate, timePassed = false
            var originalDate = DateTime.Now.AddSeconds(1);
            var originalDateNext = originalDate.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate.DayOfWeek, originalDateNext.DayOfWeek);
            Assert.AreEqual(originalDate.Date, originalDateNext.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDate2 = DateTime.Now.AddSeconds(-1);
            var originalDateNext2 = originalDate2.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate2.DayOfWeek, originalDateNext2.DayOfWeek);
            Assert.AreEqual(originalDate2.AddDays(7).Date, originalDateNext2.Date);

            // startDate = originalDate, timePassed = true
            var originalDate3 = DateTime.Now.AddDays(10).AddSeconds(-1);
            var originalDateNext3 = originalDate3.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate3.DayOfWeek, originalDateNext3.DayOfWeek);
            Assert.AreEqual(originalDate3.Date, originalDateNext3.Date);

            // startDate = originalDate, timePassed = false
            var originalDate4 = DateTime.Now.AddDays(10).AddSeconds(1);
            var originalDateNext4 = originalDate4.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate4.DayOfWeek, originalDateNext4.DayOfWeek);
            Assert.AreEqual(originalDate4.Date, originalDateNext4.Date);
        }

        [TestMethod]
        public void NextOccurrenceMonthly()
        {
            var frequencyCode = ReminderFrequencyEnum.Monthly.Code;

            // startDate = DateTime.Now, timePassed = false
            var originalDatePrev = DateTime.Now.AddMonths(-3).AddSeconds(1);
            var originalDatePrevNext = originalDatePrev.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDatePrev.AddMonths(3).Date, originalDatePrevNext.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDatePrev2 = DateTime.Now.AddMonths(-3).AddSeconds(-1);
            var originalDatePrevNext2 = originalDatePrev2.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDatePrev2.AddMonths(4).Date, originalDatePrevNext2.Date);

            // startDate = originalDate, timePassed = false
            var originalDate = DateTime.Now.AddSeconds(1);
            var originalDateNext = originalDate.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate.Date, originalDateNext.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDate2 = DateTime.Now.AddSeconds(-1);
            var originalDateNext2 = originalDate2.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate2.AddMonths(1).Date, originalDateNext2.Date);

            // startDate = originalDate, timePassed = true
            var originalDate3 = DateTime.Now.AddDays(10).AddSeconds(-1);
            var originalDateNext3 = originalDate3.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate3.DayOfWeek, originalDateNext3.DayOfWeek);
            Assert.AreEqual(originalDate3.Date, originalDateNext3.Date);

            // startDate = originalDate, timePassed = false
            var originalDate4 = DateTime.Now.AddDays(10).AddSeconds(1);
            var originalDateNext4 = originalDate4.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate4.DayOfWeek, originalDateNext4.DayOfWeek);
            Assert.AreEqual(originalDate4.Date, originalDateNext4.Date);
        }

        [TestMethod]
        public void NextOccurrenceAnnually()
        {
            var frequencyCode = ReminderFrequencyEnum.Annually.Code;

            // startDate = DateTime.Now, timePassed = false
            var originalDatePrev = DateTime.Now.AddYears(-3).AddSeconds(1);
            var originalDatePrevNext = originalDatePrev.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDatePrev.AddYears(3).Date, originalDatePrevNext.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDatePrev2 = DateTime.Now.AddYears(-3).AddSeconds(-1);
            var originalDatePrevNext2 = originalDatePrev2.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDatePrev2.AddYears(4).Date, originalDatePrevNext2.Date);

            // startDate = originalDate, timePassed = false
            var originalDate = DateTime.Now.AddSeconds(1);
            var originalDateNext = originalDate.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate.Date, originalDateNext.Date);

            // startDate = DateTime.Now, timePassed = true
            var originalDate2 = DateTime.Now.AddSeconds(-1);
            var originalDateNext2 = originalDate2.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate2.AddYears(1).Date, originalDateNext2.Date);

            // startDate = originalDate, timePassed = true
            var originalDate3 = DateTime.Now.AddDays(10).AddSeconds(-1);
            var originalDateNext3 = originalDate3.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate3.DayOfWeek, originalDateNext3.DayOfWeek);
            Assert.AreEqual(originalDate3.Date, originalDateNext3.Date);

            // startDate = originalDate, timePassed = false
            var originalDate4 = DateTime.Now.AddDays(10).AddSeconds(1);
            var originalDateNext4 = originalDate4.NextOccurrence(frequencyCode);
            Assert.AreEqual(originalDate4.DayOfWeek, originalDateNext4.DayOfWeek);
            Assert.AreEqual(originalDate4.Date, originalDateNext4.Date);
        }
    }
}