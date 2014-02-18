﻿
namespace CinemaBookingSystem
{
    public class Time
    {
        private uint hours;
        private uint minutes;

        public Time(uint hours, uint minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;
        }

        public uint Hours
        {
            get { return this.hours; }
            set
            {
                ValidationUtil.ValidateRange<uint>(0, 24, value, "Invalid time");
                this.hours = value;
            }
        }

        public uint Minutes
        {
            get { return this.minutes; }
            set
            {
                ValidationUtil.ValidateRange<uint>(0, 60, value, "Invalid time");
                this.minutes = value;
            }
        }

        public override string ToString()
        {
            string time = "";
            if (Hours < 10)
            {
                time += "0";
            }

            time += Hours;
            time += ":";

            if (Minutes < 10)
            {
                time += "0";
            }

            time += Minutes;

            return time;
        }

        public static bool operator ==(Time time1, Time time2)
        {
            if (time1.Hours == time2.hours && time1.minutes == time2.minutes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Time time1, Time time2)
        {
            if (time1.Hours == time2.hours && time1.minutes == time2.minutes)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
