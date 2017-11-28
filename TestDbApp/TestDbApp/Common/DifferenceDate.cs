using System;

namespace TestDbApp.Common
{
    /// <summary>
    /// Класс, позволяющий вычислять различие в двух датах
    /// </summary>
    internal  class DifferenceDate
    {
        private static readonly int[] MonthDay = { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public DifferenceDate(DateTime d1, DateTime d2)
        {
            DateTime toDate;
            DateTime fromDate;
            if (d1 > d2)
            {
                fromDate = d2;
                toDate = d1;
            }
            else
            {
                fromDate = d1;
                toDate = d2;
            }

            var increment = 0;

            if (fromDate.Day > toDate.Day)
            {
                increment = MonthDay[fromDate.Month - 1];

            }

            if (increment == -1)
            {
                increment = DateTime.IsLeapYear(fromDate.Year) ? 29 : 28;
            }
            if (increment != 0)
            {
                Days = toDate.Day + increment - fromDate.Day;
                increment = 1;
            }
            else
            {
                Days = toDate.Day - fromDate.Day;
            }

            if (fromDate.Month + increment > toDate.Month)
            {
                Months = toDate.Month + 12 - (fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                Months = toDate.Month - (fromDate.Month + increment);
                increment = 0;
            }

            Years = toDate.Year - (fromDate.Year + increment);

        }

        /// <summary>
        /// Получение разницы в годах
        /// </summary>
        public int Years { get; }
        /// <summary>
        /// Получение разницы в месяцах
        /// </summary>
        public int Months { get; }
        /// <summary>
        /// Получение разницы в днях
        /// </summary>
        public int Days { get; }
    }
}
