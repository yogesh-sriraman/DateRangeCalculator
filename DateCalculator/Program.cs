namespace DateCalculator
{
    public class Program
    {
        static void DoTask1(DateTime firstDate, DateTime secondDate, BusinessDayCounter businessDayCounter)
        {
            int weekdaysBetweenTwoDates = businessDayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);

            Console.WriteLine($"Week days between " +
                $"{firstDate.ToString("dd MMMM yyyy")} and " +
                $"{secondDate.ToString("dd MMMM yyyy")} is " +
                $"{weekdaysBetweenTwoDates}");
        }

        static void DoTask2(DateTime firstDate, DateTime secondDate, BusinessDayCounter businessDayCounter)
        {
            List<DateTime> publicHolidays = new()
            {
                new(2016, 4, 25),
                new(2016, 6, 13),
                new(2016, 12, 25),
                new(2016, 12, 26),
                new(2017, 1, 1)
            };

            int businessDaysBetweenTwoDays = businessDayCounter
                .BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            Console.WriteLine($"Business days between " +
                $"{firstDate.ToString("dd MMMM yyyy")} and " +
                $"{secondDate.ToString("dd MMMM yyyy")} is " +
                $"{businessDaysBetweenTwoDays}");
        }

        static void DoTask3(DateTime firstDate, DateTime secondDate, BusinessDayCounter businessDayCounter)
        {
            IHoliday queensBirthday = new DayOfWeekOccurenceHoliday(2016, 6, 2, DayOfWeek.Monday);

            IHoliday newYears = new PublicHoliday();
            newYears.SetDate(2017, 1, 1);
            newYears.IsFloating = true;

            IHoliday anzacDay = new PublicHoliday();
            anzacDay.SetDate(2016, 4, 25);
            anzacDay.IsFloating = false;

            IHoliday christmasDay1 = new PublicHoliday();
            christmasDay1.SetDate(2016, 12, 25);
            christmasDay1.IsFloating = false;

            IHoliday christmasDay2 = new PublicHoliday();
            christmasDay2.SetDate(2016, 12, 26);
            christmasDay2.IsFloating = false;

            List<IHoliday> holidays = new() { queensBirthday, christmasDay1,
                christmasDay2, newYears, anzacDay};

            int businessDaysBtwn2Days = businessDayCounter
                .BusinessDaysBetweenTwoDates(firstDate, secondDate, holidays);
            Console.WriteLine($"Business days between " +
                $"{firstDate.ToString("dd MMMM yyyy")} and " +
                $"{secondDate.ToString("dd MMMM yyyy")} is " +
                $"{businessDaysBtwn2Days}");

            Console.WriteLine($"Queens birthday - {queensBirthday.GetDate().ToString("dd MMMM yyyy")}");
            Console.WriteLine($"Actual New Years holiday - {newYears.GetDate().ToString("dd MMMM yyyy")}");
        }


        static void Main(string[] args)
        {
            BusinessDayCounter businessDayCounter = new();
            DateTime firstDate = new(2016, 4, 24);
            DateTime secondDate = new(2017, 1, 4);

            DoTask1(firstDate, secondDate, businessDayCounter);
            DoTask2(firstDate, secondDate, businessDayCounter);
            DoTask3(firstDate, secondDate, businessDayCounter);

            Console.WriteLine("Press Any to exit... ");
            Console.ReadKey();
        }
    }
}