﻿
namespace CinemaBookingSystem
{
    class KidsTicket : Ticket, IPriceCalculator
    {     
        const int PercentageDiscount = 50;

        public KidsTicket(Movie movie, decimal price)
            : base(movie, price)
        {
        }

        public override void CalculatePrice()
        {
            decimal descount = price * (PercentageDiscount / 100);
            this.Price = price - descount;
        }
    }
}