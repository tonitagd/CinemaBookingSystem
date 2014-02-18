﻿using System;
using System.Text.RegularExpressions;

namespace CinemaBookingSystem
{
    static class ValidationUtil
    {
        public static void NullOrEmptyStringValidation(string value, string message)
        {
            if (IsStringNullOrEmpty(value))
            {
                throw new MovieException(message, new ArgumentException());
            }
        }

        public static bool IsStringNullOrEmpty(string value)
        {
            return String.IsNullOrEmpty(value.Trim());
        }

        public static void ValidateRange<T>(T min, T max, T value, string message) where T : IComparable<T>
        {
            if (value.CompareTo(max) > 0 || value.CompareTo(min) < 0)
            {
                throw new MovieException(message, new ArgumentOutOfRangeException());
            }
        }

        public static void ValidateDate(uint year, uint month, uint value, string message)
        {

            int daysInMonth = DateTime.DaysInMonth((int)year, (int)month);

            if (value > daysInMonth || value < 1)
            {
                throw new MovieException(message, new ArgumentOutOfRangeException());
            }

        }

        public static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
    }
}
