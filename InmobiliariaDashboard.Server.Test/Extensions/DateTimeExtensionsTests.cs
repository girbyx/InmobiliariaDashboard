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
            var originalDate3 = DateTime.Now.AddDays(7);
            var originalDateNext3 = originalDate3.NextDayOfWeek();
            Assert.AreEqual(originalDate3.DayOfWeek, originalDateNext3.DayOfWeek);
            Assert.AreEqual(originalDate3.Date, originalDateNext3.Date);
        }
    }
}