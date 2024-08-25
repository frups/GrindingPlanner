using GrindingPlanner.Shared.Utils;
using System.Globalization;

namespace GrindingPlannerUnitTests
{
    public class DateWeekResolverTest
    {
        [Fact]
        public void GetWeekNumber_11thJuly2024ShouldBeWeek28()
        {
            //Arrange
            DateTime date = new DateTime(2024, 7, 11);

            //Act
            int weekNumber = DateWeekResolver.GetWeekNumber(date);

            //Assert
            Assert.Equal(28, weekNumber);
        }

        [Fact]
        public void GetWeekNumber_1stJanuary2024ShouldBeWeek1()
        {
            //Arrange
            DateTime date = new DateTime(2024, 1, 1);

            //Act
            int weekNumber = DateWeekResolver.GetWeekNumber(date);

            //Assert
            Assert.Equal(1, weekNumber);
        }

        [Fact]
        public void GetWeekNumber_31December2024ShouldBeWeek1()//overlapping with 1 week of 2025
        {
            //Arrange
            DateTime date = new DateTime(2024, 1, 1);

            //Act
            int weekNumber = DateWeekResolver.GetWeekNumber(date);

            //Assert
            Assert.Equal(1, weekNumber);
        }

        [Fact]
        public void GetWeekNumber_AllWeeksIn2024ShouldBeCorrect()
        {
            //Arrange
            DateTime date = new DateTime(2024, 1, 1);
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            //Act
            for (int i = 1; i <= 52; i++)
            {
                int weekNumber = DateWeekResolver.GetWeekNumber(date);

                //Assert
                Assert.Equal(i, weekNumber);
                date = date.AddDays(7);
            }
        }

        [Fact]
        public void GetCurrentWeekNumber_()
        {
            //Arrange
            DateTime date = DateTime.Now;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            //Act
            int weekNumber = DateWeekResolver.GetCurrentWeekNumber();

            //Assert
            Assert.Equal(cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), weekNumber);
        }

        [Fact]
        public void GetFirstDayOfWeek_AllWeeksIn2024ShouldBeCorrect()
        {
            //Arrange
            DateTime date = new DateTime(2024, 1, 1);
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            //Act
            for (int i = 1; i <= 52; i++)
            {
                DateTime firstDayOfWeek = DateWeekResolver.GetFirstDayOfWeek(date.Year, i);

                //Assert
                Assert.Equal(date, firstDayOfWeek);
                date = date.AddDays(7);
            }
        }

        [Fact]

        public void GetLastDayOfWeek_AllWeeksIn2024ShouldBeCorrect()
        {
            //Arrange
            DateTime date = new DateTime(2024, 1, 7);
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            //Act
            for (int i = 1; i <= 52; i++)
            {
                DateTime lastDayOfWeek = DateWeekResolver.GetLastDayOfWeek(date.Year, i);

                //Assert
                Assert.Equal(date, lastDayOfWeek);
                date = date.AddDays(7);
            }
        }

        [Fact]
        public void GetFirstDayOfCurrentWeek_()
        {
            //Arrange
            DateTime date = DateTime.Now;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            //Act
            DateTime firstDayOfWeek = DateWeekResolver.GetFirstDayOfCurrentWeek();

            //Assert
            Assert.Equal(DateWeekResolver.GetFirstDayOfWeek(date.Year, cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)), firstDayOfWeek);
        }

        [Fact]
        public void GetLastDayOfCurrentWeek_()
        {
            //Arrange
            DateTime date = DateTime.Now;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            //Act
            DateTime lastDayOfWeek = DateWeekResolver.GetLastDayOfCurrentWeek();

            //Assert
            Assert.Equal(DateWeekResolver.GetLastDayOfWeek(date.Year, cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)), lastDayOfWeek);
        }

        [Fact]
        public void GetFirstDayOfFollowingWeek_10FollowingWeeksShouldBeCorrect()
        {
            //Arrange
            DateTime date = DateTime.Now;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            //Act
            for (int i = 1; i <= 10; i++)
            {
                DateTime firstDayOfWeek = DateWeekResolver.GetFirstDayOfFollowingWeek(i);

                //Assert
                Assert.Equal(DateWeekResolver.GetFirstDayOfWeek(date.Year, cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) + i), firstDayOfWeek);
            }
        }

        [Fact]
        public void GetLastDateOfFollwingNextWeek_10FollowingWeeksShouldBeCorrect()
        {
            //Arrange
            DateTime date = DateTime.Now;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            //Act
            for (int i = 1; i <= 10; i++)
            {
                DateTime lastDayOfWeek = DateWeekResolver.GetLastDateOfFollwingNextWeek(i);

                //Assert
                Assert.Equal(DateWeekResolver.GetLastDayOfWeek(date.Year, cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) + i), lastDayOfWeek);
            }
        }
    }
}