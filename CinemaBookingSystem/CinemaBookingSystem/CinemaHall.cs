﻿using System;

namespace CinemaBookingSystem
{
    public class CinemaHall
    {
        private string id;
        private int rows;
        private int seats;

        private int maxRows = Seat.maxRows;
        private int maxSeats = Seat.maxSeats;

        public CinemaHall(string id, int rows, int seats)
        {
            this.Id = id;
            this.Rows = rows;
            this.Seats = seats;
        }

        public string Id
        {
            get { return this.id; }
            protected set
            {
                ValidationUtil.NullOrEmptyStringValidation(value, "Hall ID should be provided. ");
                this.id = value;
            }
        }

        public int Rows
        {
            get { return this.rows; }
            protected set
            {
                ValidationUtil.ValidateRange<int>(0, maxRows, value, String.Format("Number of rows should be from 1 to {0}", maxRows));
                this.rows = value;
            }
        }

        public int Seats
        {
            get { return this.seats; }
            protected set
            {
                ValidationUtil.ValidateRange<int>(0, maxSeats, value, String.Format("Number of seats should be from 1 to {0}", maxSeats));
                this.seats = value;
            }
        }
    }
}
