using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator
{
    // A type of Public Holiday. Uses day of the week occurence in a certain week of every year.
    public class DayOfWeekOccurenceHoliday : PublicHoliday
    {
        public int weekNumber;
        public DayOfWeek dayOfWeek;

        public DayOfWeekOccurenceHoliday(int year, int month, int weekNumber, DayOfWeek dayOfWeek)
        {
            this.year = year;
            this.month = month;
            this.weekNumber = weekNumber;
            this.dayOfWeek = dayOfWeek;
        }

        public override DateTime GetDate()
        {
            // If the date is already computed, just return the date. Do not compute
            if (dateComputed)
            {
                return dt;
            }

            // Create a temporary date and then compute to get the actual date.
            dt = new DateTime(year, month, 1);

            // Initial offset. Add 7 days for difference in week.
            int offsetDays = (weekNumber - 1) * 7;

            // Compute the remaining days
            ComputeDate(dt.DayOfWeek, dayOfWeek, offsetDays);

            // return computed date
            return dt;
        }
    }
}
