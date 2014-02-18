﻿
namespace CinemaBookingSystem
{
   abstract class Ticket : IPriceCalculator
    {
        public Movie Movie { get; private set; }
        public string ticketID { get; set; }

        protected decimal price;

        public Ticket(Movie movie, decimal price)
        {
            this.Movie = movie;
            this.Price = price;
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                ValidationUtil.ValidateRange<decimal>(0, 40, value, "Ticket price should be higher than 0$ and lower than 40$");
                this.price = value;
            }
        }

        public abstract void CalculatePrice();
    }
}
