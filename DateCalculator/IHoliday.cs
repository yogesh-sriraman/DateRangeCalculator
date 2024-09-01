using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator
{
    // Interface to handle different types of holidays.
    public interface IHoliday
    {
        DateTime GetDate();
        void SetDate(int year, int month, int date);
        bool IsFloating { get; set; }
        bool IsWeekend();
    }
}
