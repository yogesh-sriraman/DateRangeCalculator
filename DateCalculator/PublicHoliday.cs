using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator
{
    // Base class for holidays
    public class PublicHoliday : IHoliday
    {
        protected DateTime dt;
        protected bool dateComputed;


        protected bool _isFloating;
        public bool IsFloating
        {
            get => _isFloating;
            set => _isFloating = value;
        }

        protected int year;

        protected int month;
        protected int date;


        protected void ComputeDate(DayOfWeek currDayOfWeek, DayOfWeek targetDayOfWeek, int offsetDays = 0)
        {
            int currDW = (int)currDayOfWeek;
            int targetDW = (int)targetDayOfWeek;

            // Compute how many days are in between the current day of week and target day of week
            offsetDays += (targetDW - currDW + 7) % 7;

            // Add the offset calculated
            dt = dt.AddDays(offsetDays);
            dateComputed = true;
        }

        public virtual DateTime GetDate()
        {
            // If it is not a floating holiday, return the date directly
            if (!_isFloating)
            {
                return dt;
            }

            // If the date is already computed, just return the date. Do not compute
            if (dateComputed)
            {
                return dt;
            }

            // Compute the remaining days
            ComputeDate(dt.DayOfWeek, DayOfWeek.Monday);
            return dt;
        }
        public void SetDate(int year, int month, int date)
        {
            this.year = year;
            this.month = month;
            this.date = date;

            dt = new DateTime(year, month, date);
        }

        public virtual bool IsWeekend()
        {
            // Compute date if it is not yet computed
            if(!dateComputed)
            {
                GetDate();
            }

            // Check for weekend. Weekend values are either 6 or 0.
            int dayOfWeek = (int)dt.DayOfWeek;
            return (dayOfWeek % 6) == 0;
        }
    }
}
