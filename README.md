# DateRangeCalculator

## Steps to execute
1. Provide two dates - ***firstDate*** and ***secondDate*** in ***Program.cs***
2. Call **DoTask1** which calculates the number of working days between the given two dates.
3. Call **DoTask2** which calculates the number of business days between the given two dates and a list of holidays.
4. Call **DoTask3** which calculates the number of business days between the given two dates and a list of holidays with different conditions (Conditions mentioned below).

## Task One: Weekdays Between Two Dates
Calculates the number of weekdays in between two dates.
1. Weekdays are Monday, Tuesday, Wednesday, Thursday, Friday.
2. The returned count should not include either firstDate or secondDate - <br />
    e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
3. If secondDate is equal to or before firstDate, return 0.
4. Eg: **firstDate** - 7th Oct 2013, **secondDate** - 1st Jan 2014 => **Result** : 61.

## Task Two: Business Days Between Two Dates
Calculate the number of business days in between two dates.
1. Business days are Monday, Tuesday, Wednesday, Thursday, Friday, but excluding any dates which appear in the supplied list of public holidays.
2. The returned count should not include either firstDate or secondDate - <br />
    e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
3. If secondDate is equal to or before firstDate, return 0.
4. Eg: List of public holidays: 25th and 26th Dec 2013. <br />
    **firstDate** - 24th Dec 2013, **secondDate** - 27th Dec 2013 => **Result** : 0.

## Task Three: More Holidays
Desinged a class that incorporates the following conditions for holidays.

1. Public holidays which are always on the same day, e.g. Anzac Day on April 25th every year.
2. Public holidays which are always on the same day, except when that falls on a weekend. e.g. <br />
    New Year's Day on January 1st every year, unless that is a Saturday or Sunday, in which case the holiday is the next Monday.
3. Public holidays on a certain occurrence of a certain day in a month. e.g. Queen's Birthday on the
second Monday in June every year.














