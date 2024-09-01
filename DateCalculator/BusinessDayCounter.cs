using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator
{
    public class BusinessDayCounter
    {
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            int numOfDays = (secondDate - firstDate).Days - 1;
            if (numOfDays < 1)
            {
                return 0;
            }

            /* Fetch the number of full weeks and the remaining extra days.
             * Example: 12 Days -> 1 full week and 5 extra days
             */
            int numOfWeeks = numOfDays / 7;
            int numOfExtraDays = (numOfDays % 7);

            // Initialize Number of working days. This is just 5 times the number of full weeks.
            // Concept: Each full week has 5 working days.
            int numOfWorkingDays = numOfWeeks * 5;

            // If the difference is a multiple of 7. Then we have only full weeks. Return the result.
            if (numOfExtraDays == 0)
            {
                return numOfWorkingDays;
            }

            // Add the extra days. We can remove the weekends later.
            numOfWorkingDays += numOfExtraDays;

            /*
             * Concept: If we consider the firstDate is on Thursday,
             * then we can add the extra days to it to find the end day of the week.
             * If this is less than Thursday, then we can crossed Saturday and Sunday.
             * Else, we check if either the first day or last day is a Sunday or Saturday respectively.
             * If so, we have just crossed Sunday or Saturday.
             */
            int startDay = (int)firstDate.DayOfWeek;
            int endDay = (startDay + numOfExtraDays - 1) % 7;

            if (endDay < startDay)
            {
                return numOfWorkingDays - 2;
            }

            if (startDay == 0 || endDay == 6)
            {
                return numOfWorkingDays - 1;
            }

            return numOfWorkingDays;
        }
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime>
        publicHolidays)
        {
            // Get all weekdays between these two dates
            int numOfBusinessDays = WeekdaysBetweenTwoDates(firstDate, secondDate);

            for(int i = 0; i < publicHolidays.Count; i++)
            {
                DateTime publicHoliday = publicHolidays[i];

                // Check if the given holiday is in between first and last.
                if(!(publicHoliday > firstDate && publicHoliday < secondDate))
                {
                    // If not, ignore. Move on to next holiday
                    continue;
                }

                // Get the day of week and check if it is a weekend.
                int dayOfWeek = (int)publicHoliday.DayOfWeek;
                bool isWeekend = (dayOfWeek % 6) == 0;
                if (isWeekend)
                {
                    // If it is a weekend, ignore. Because we have already ignored them in the first step.
                    continue;
                }

                // A valid holiday. So reduce the number of business days computed from above
                --numOfBusinessDays;
            }
            
            return numOfBusinessDays;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate,
            IList<IHoliday> publicHolidays)
        {
            // Get all weekdays between these two dates
            int numOfBusinessDays = WeekdaysBetweenTwoDates(firstDate, secondDate);

            for(int i = 0; i < publicHolidays.Count; i++)
            {
                // Get the holiday interface
                IHoliday holiday = publicHolidays[i];

                // Check if it is a weekend. If so, ignore.
                if(holiday.IsWeekend())
                {
                    continue;
                }

                // Get the date from the interface.
                DateTime date = holiday.GetDate();

                // Check if the given holiday is in between first and last.
                if (!(date > firstDate && date < secondDate))
                {
                    // If not, ignore. Move on to next holiday
                    continue;
                }

                // A valid holiday. So reduce the number of business days computed from above
                --numOfBusinessDays;
            }

            return numOfBusinessDays;
        }
    }
}
