using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    public static class HolidayTest
    {
        public static bool IsChristmas()
        {
            DateTime HolidayBegin = new DateTime(2020, 12, 15);
            DateTime HolidayEnd = new DateTime(2020, 12, 28);
            if (DateTime.Now.Day >= HolidayBegin.Day && DateTime.Now.Month >= HolidayBegin.Month
                && DateTime.Now.Day <= HolidayEnd.Day && DateTime.Now.Month <= HolidayEnd.Month)
            {
                return true;
            }
            return false;
        }

        public static bool IsThanksgiving()
        {
            DateTime HolidayBegin = new DateTime(2020, 11, 20);
            DateTime HolidayEnd = new DateTime(2020, 11, 30);
            if (DateTime.Now.Day >= HolidayBegin.Day && DateTime.Now.Month >= HolidayBegin.Month
                && DateTime.Now.Day <= HolidayEnd.Day && DateTime.Now.Month <= HolidayEnd.Month)
            {
                return true;
            }
            return false;
        }

        public static bool IsHoloween()
        {
            DateTime HoloweenBegin = new DateTime(2020, 10, 16);
            DateTime HoloweenEnd = new DateTime(2020, 10, 31);
            if (DateTime.Now.Day >= HoloweenBegin.Day && DateTime.Now.Month >= HoloweenBegin.Month
                && DateTime.Now.Day <= HoloweenEnd.Day && DateTime.Now.Month <= HoloweenEnd.Month)
            {
                return true;
            }
            return false;
        }
    }
}
